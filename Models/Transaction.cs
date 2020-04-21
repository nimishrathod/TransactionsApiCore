using System;

namespace TransactionsApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FundId { get; set; }
        public MutualFund Fund { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Nav { get; set; }
        public decimal Units { get; set; }
    }
}
