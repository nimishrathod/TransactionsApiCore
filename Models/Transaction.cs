using System;

namespace TransactionsApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string SchemeCode { get; set; }
        public MutualFund MutualFund { get; set; }
        public decimal Amount { get; set; }
        public decimal Units { get; set; }
        public decimal PurchaseNav { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
