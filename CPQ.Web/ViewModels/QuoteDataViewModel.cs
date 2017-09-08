using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web.ViewModels
{
    public class QuoteDataViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal NetAmount { get; set; }
        public decimal CustomerAmount { get; set; }
        public int? PaymentTerms { get; set; }
        public string PriceBookId { get; set; }
        public bool? LinesGrouped { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsPrimary { get; set; }
        public string Type { get; set; }
        public List<QuoteLineViewModel> Lines { get; set; }
        public List<GroupViewModel> Groups { get; set; }

        public QuoteDataViewModel()
        {
            Lines = new List<QuoteLineViewModel>();
            Groups = new List<GroupViewModel>();
        }
    }
}