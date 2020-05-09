using System;
using System.Collections.Generic;

namespace TransactionsApi.Models
{
    public class MutualFund
    {
        public string SchemeCode { get; set; }
        public string IsinGrowthDivPayOut { get; set; }
        public string IsinDivReInvest { get; set; }
        public string SchemeName { get; set; }
        public decimal CurrentNav { get; set; }
        public DateTime CurrentNavDate { get; set; }

    }
}
