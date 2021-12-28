using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        public DbSet<StaffAccount> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP-83O4PRPJ\MSSQLSERVER01; Initial Catalog = Banking_Application; Integrated Security = True");      
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
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

            modelBuilder.Entity<StaffAccount>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.StaffAccount)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.transactions)
                .HasForeignKey(d => d.BankId);

                entity.HasOne(d => d.Account)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId);         
            });
        }
    }
}
