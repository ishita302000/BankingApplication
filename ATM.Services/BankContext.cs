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
        private DbSet<Transaction> transaction;

        public DbSet<Bank> Bank { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Account> Account
        {
            get; set;
        }
        public DbSet<Transaction> Transaction { get => transaction; set => transaction = value; }
        public DbSet<Staff> Staff { get; set; }

    /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.SqlServer(@"Data Source=LAPTOP-83O4PRPJ\MSSQLSERVER01;Initial Catalog=Banking_Application;Integrated Security=True");
            object p = optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-83O4PRPJ\MSSQLSERVER01;Initial Catalog=Banking_Application;Integrated Security=True");

        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
        }
    
       // public class ApplicationDbContext : DbContext
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source = LAPTOP - 83O4PRPJ\MSSQLSERVER01; Initial Catalog = Banking_Application; Integrated Security = True");

            }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = LAPTOP - 83O4PRPJ\MSSQLSERVER01; Initial Catalog = Banking_Application; Integrated Security = True");

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
