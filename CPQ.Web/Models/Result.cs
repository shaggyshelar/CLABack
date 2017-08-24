using CPQ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.Models
{
    public class Result
    {
        public bool IsRuleEmpty { get; set; }
        public bool IsRuleValid { get; set; }
        public string Output { get; set; }
        public string ClientInvalidData { get; set; }
        public Product Patient { get; set; }

        public Result()
        {
            this.IsRuleEmpty = false;
            this.IsRuleValid = true;
        }
    }
}