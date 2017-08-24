﻿using CodeEffects.Rule.Core;
using CodeEffects.Rule.Models;
using CodeEffects.Rule.Mvc;
using CPQ.Domain;
using CPQ.Web.Models;
using CPQ.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPQ.Web.Controllers
{
    public class AjaxController : Controller
    {
        public AjaxController()
        {
        }

        public ActionResult Index()
        {
            // Create a new rule model and store it in the bag
            // The view passes it to the RuleEditor
            ViewBag.Rule = RuleModel.Create(typeof(Product));

            return View();
        }

        [HttpPost]
        public ActionResult LoadSettings()
        {
            // For client-only action calls, the MVC pattern "model-controller-view" gets broken
            // because there is no view anymore - raw data travels between the client and the server
            // without any need to create or return the markup. For such calls, the place where the RuleEditor
            // would be normally declared does not exist anymore. Therefore, we need to declare it
            // programmatically. The GetRuleEditor() method does that. It also creates the model and passes
            // it to the instance of the rule editor.
            RuleEditor editor = this.GetRuleEditor();

            // Get UI settings
            string settings = editor.GetClientSettings();

            // Send the settings back to the client
            return Json(settings, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult LoadRule(string ruleId)
        {
            // Load the rule from the storage file by its ID
            string ruleXml = StorageService.LoadRuleXml(ruleId);

            // See the comments in the LoadSettings() method
            RuleEditor editor = this.GetRuleEditor(ruleXml);

            // Get the rule's client data
            string ruleJson = editor.GetClientRuleData();

            // Send it back to the server
            return Json(ruleJson, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult DeleteRule(string ruleId)
        {
            try
            {
                // Delete the rule from the storage file by its ID
                StorageService.DeleteRule(ruleId);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.DenyGet);
            }

            // Respond to the client's request with no data
            return Json(null, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult SaveRule(string ruleData)
        {
            Result result = new Result();

            // See the comments in the LoadSettings() method
            RuleEditor editor = this.GetRuleEditor();

            // Load the rule into the editor
            editor.LoadClientData(ruleData);

            if (editor.Rule.IsEmpty())
            {
                result.IsRuleEmpty = true;
            }
            else if (!editor.Rule.IsValid(StorageService.LoadRuleXml))
            {
                result.IsRuleValid = false;
                // Load the json string of invalid data into the Result object
                result.ClientInvalidData = editor.GetClientInvalidData();
            }
            else
            {
                // Save the rule
                StorageService.SaveRule(editor.Rule.Id.ToString(), editor.Rule.GetRuleXml(), editor.Rule.IsLoadedRuleOfEvalType == null ? true : (bool)editor.Rule.IsLoadedRuleOfEvalType);
                // Send ID of this rule to the client
                result.Output = editor.Rule.Id.ToString();
            }

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult EvaluateRule(Product patient, string ruleData)
        {
            Result result = new Result();

            patient.DefaultQuantity = "2";

            // See the comments in the LoadSettings() method
            RuleEditor editor = this.GetRuleEditor();

            // Load the rule into the editor
            editor.LoadClientData(ruleData);

            // We are not saving the rule, just evaluating it. Tell the editor not to enforce the rule name validation
            editor.Rule.SkipNameValidation = true;

            if (editor.Rule.IsEmpty())
            {
                result.IsRuleEmpty = true;
            }
            else if (!editor.Rule.IsValid(StorageService.LoadRuleXml))
            {
                result.IsRuleValid = false;
                // Load the json string of invalid data into the Result object
                result.ClientInvalidData = editor.GetClientInvalidData();
            }
            else
            {
                // Create an instance of the Evaluator class. Because our rules might reference other rules of evaluation type
                // we use constructor that takes rule's XML and delegate of the method that can load referenced rules by their IDs.
                Evaluator<Product> evaluator = new Evaluator<Product>(editor.Rule.GetRuleXml(), StorageService.LoadRuleXml);

                // Evaluate the patient against the rule
                bool success = evaluator.Evaluate(patient);

                // Return the evaluated patient back to the client
                result.Patient = patient;

                // Output the result of the evaluation to the client
                result.Output = string.IsNullOrWhiteSpace(patient.Output) ? "The rule evaluated to " + success.ToString() : patient.Output;
            }

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private RuleEditor GetRuleEditor()
        {
            return this.GetRuleEditor(null);
        }

        private RuleEditor GetRuleEditor(string ruleXml)
        {
            RuleEditor editor = new RuleEditor("ruleEditor");

            // Client-only editor
            editor.ClientOnly = true;

            editor.Mode = CodeEffects.Rule.Common.RuleType.Execution;

            if (ruleXml == null)
                editor.Rule = RuleModel.Create(typeof(Product));
            else
                editor.Rule = RuleModel.Create(ruleXml, typeof(Product));

            editor.ToolBarRules = StorageService.GetAllRules();
            editor.ContextMenuRules = StorageService.GetEvaluationRules();

            return editor;
        }
    }
}