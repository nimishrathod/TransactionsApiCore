using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            modelBuilder.Entity<MutualFund>()
                .HasKey(fund => fund.SchemeCode);

            modelBuilder.Entity<Transaction>()
                .HasOne<MutualFund>(t => t.MutualFund)
                .WithMany()
                .HasForeignKey(t => t.SchemeCode);
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<MutualFund> MutualFunds { get; set; }
    }
}