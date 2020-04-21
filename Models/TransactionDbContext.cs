using Microsoft.EntityFrameworkCore;

namespace TransactionsApi.Models
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne<MutualFund>(t => t.Fund)
                .WithMany()
                .HasForeignKey(t => t.FundId);
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MutualFund> Funds { get; set; }
    }
}