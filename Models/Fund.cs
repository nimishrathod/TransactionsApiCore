using System;
using System.Collections.Generic;

namespace TransactionsApi.Models
{
    public class MutualFund
    {
        public int Id { get; set; }
        public string FundCode { get; set; }
        public string FundName { get; set; }
        public decimal CurrentNav { get; set; }
        public DateTime CurrentNavDate { get; set; }
        public decimal LastNav { get; set; }
        public DateTime LastNavDate { get; set; }
        // public ICollection<Transaction> Transactions { get; set; }
    }
}
