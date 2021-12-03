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
     //     Bank have accounts ( OnChangeEventHandler to many )
       //     bank have currency 

    }
}
