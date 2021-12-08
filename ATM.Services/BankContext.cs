using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.Services
{
    public class BankContext : DbContext
    {
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Account> Account
        {
            get; set;
        }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP - 83O4PRPJ\MSSQLSERVER01; Initial Catalog = Banking_Application; Integrated Security = True");      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.Currencies)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.StaffAccount)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.transactions)
                .HasForeignKey(d => d.SenderBankId);

                entity.HasOne(d => d.Bank)
                .WithMany(p => p.transactions)
                .HasForeignKey(d => d.RecieverBankId);

                entity.HasOne(d => d.Account)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SenderAccountId);

                entity.HasOne(d => d.Account)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.RecieverAccountId);
            });
        }
    }
}
