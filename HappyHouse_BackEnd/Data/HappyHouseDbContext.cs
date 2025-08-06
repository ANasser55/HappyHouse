using HappyHouse_Server.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace HappyHouse_Server.Data
{
    public class HappyHouseDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Ledger> Ledgers { get; set; }
        public DbSet<MonthInstallment> MonthInstallments { get; set; }


        public HappyHouseDbContext(DbContextOptions<HappyHouseDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("customers").HasKey(x => x.CustomerId);
            modelBuilder.Entity<Installment>().ToTable("installments").HasKey(x => x.InstallmentId);
            modelBuilder.Entity<Debt>().ToTable("debts").HasKey(x => x.DebtId);
            modelBuilder.Entity<Debtor>().ToTable("debtors").HasKey(x => x.DebtorId);
            modelBuilder.Entity<Transaction>().ToTable("transactions").HasKey(x => x.TransactionId);
            modelBuilder.Entity<Ledger>().ToTable("ledger").HasKey(x => x.LedgerId);
            modelBuilder.Entity<MonthInstallment>().ToView("vw_MonthInstallments").HasNoKey();

            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Customer>().Property(c => c.CustomerName).HasColumnName("customer_name");
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasColumnName("customer_phone");
            //modelBuilder.Entity<Customer>().Property(c => c.NextPayment).HasColumnName("customer_next_payment");
            modelBuilder.Entity<Customer>().Property(c => c.RemainingAmount).HasColumnName("customer_remaining");

            modelBuilder.Entity<Installment>().Property(i => i.InstallmentId).HasColumnName("installment_id");
            modelBuilder.Entity<Installment>().Property(i => i.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Installment>().Property(i => i.Amount).HasColumnName("amount");
            modelBuilder.Entity<Installment>().Property(i => i.PaymentPerMonth).HasColumnName("payment_per_month");
            modelBuilder.Entity<Installment>().Property(i => i.RemainingAmount).HasColumnName("remaining_amount");
            modelBuilder.Entity<Installment>().Property(i => i.StartDate).HasColumnName("start_date");
            modelBuilder.Entity<Installment>().Property(i => i.NextDate).HasColumnName("next_date");
            modelBuilder.Entity<Installment>().Property(i => i.isPaid).HasColumnName("paid");
            modelBuilder.Entity<Installment>().Property(i => i.Description).HasColumnName("description");

            modelBuilder.Entity<Debt>().Property(d => d.DebtId).HasColumnName("debt_id");
            modelBuilder.Entity<Debt>().Property(d => d.DebtorId).HasColumnName("debtor_id");
            modelBuilder.Entity<Debt>().Property(d => d.Amount).HasColumnName("debt_amount");
            modelBuilder.Entity<Debt>().Property(d => d.PaidAmount).HasColumnName("debt_paid");
            modelBuilder.Entity<Debt>().Property(d => d.Description).HasColumnName("debt_description");

            modelBuilder.Entity<Debtor>().Property(d => d.DebtorId).HasColumnName("debtor_id");
            modelBuilder.Entity<Debtor>().Property(d => d.Name).HasColumnName("debtor_name");
            modelBuilder.Entity<Debtor>().Property(d => d.Phone).HasColumnName("debtor_phone");

            modelBuilder.Entity<Transaction>().Property(t => t.TransactionId).HasColumnName("transaction_id");
            modelBuilder.Entity<Transaction>().Property(t => t.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<Transaction>().Property(t => t.InstallmentId).HasColumnName("installment_id");
            modelBuilder.Entity<Transaction>().Property(t => t.DebtorId).HasColumnName("debtor_id");
            modelBuilder.Entity<Transaction>().Property(t => t.LedgerId).HasColumnName("ledger_id");
            modelBuilder.Entity<Transaction>().Property(t => t.Date).HasColumnName("transaction_date");
            modelBuilder.Entity<Transaction>().Property(t => t.TransactorName).HasColumnName("transactor_name");
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasColumnName("transaction_amount");
            modelBuilder.Entity<Transaction>().Property(t => t.Type).HasColumnName("transaction_type");
            modelBuilder.Entity<Transaction>().Property(t => t.Description).HasColumnName("transaction_description");

            modelBuilder.Entity<Ledger>().Property(l => l.LedgerId).HasColumnName("ledger_id");
            modelBuilder.Entity<Ledger>().Property(l => l.Date).HasColumnName("date");
            modelBuilder.Entity<Ledger>().Property(l => l.Income).HasColumnName("income");
            modelBuilder.Entity<Ledger>().Property(l => l.Expense).HasColumnName("expense");
            modelBuilder.Entity<Ledger>().Property(l => l.Balance).HasColumnName("balance");

            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.InstallmentId).HasColumnName("installment_id");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.CustomerId).HasColumnName("customer_id");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.CustomerName).HasColumnName("customer_name");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.MonthlyAmount).HasColumnName("payment_per_month");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.NextDate).HasColumnName("next_date");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.RemainingAmount).HasColumnName("remaining_amount");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.DelayDays).HasColumnName("delay_days");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.RemainingInstallments).HasColumnName("installments_remaining");
            modelBuilder.Entity<MonthInstallment>().Property(mi => mi.Description).HasColumnName("description");

        }

    }
}
