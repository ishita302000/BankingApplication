using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ATM.Models;
using Microsoft.EntityFrameworkCore;
using ATM.Services.DbModels;

namespace ATM.Services
{
    public class BankContext : DbContext
    {
        public DbSet<DbBankModel> Bank { get; set; }
        public DbSet<DbCurrencyModel> Currency { get; set; }
        public DbSet<DbCustomerModel> Account { get; set; }
        public DbSet<DbTransactionModel> Transaction { get; set; }
        public DbSet<DbEmployeeModel> Staff { get; set; }

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

            modelBuilder.Entity<DbCurrencyModel>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.Currencies)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<DbCustomerModel>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.CustomerAccounts)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<DbEmployeeModel>(entity =>
            {
                entity.HasOne(d => d.Bank)
                .WithMany(p => p.StaffAccounts)
                .HasForeignKey(d => d.BankId);
            });

            modelBuilder.Entity<DbTransactionModel>(entity =>
            {
               
                entity.HasOne(d => d.Customer)
                .WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SrcAccount);         
            });
        }
    }
}
