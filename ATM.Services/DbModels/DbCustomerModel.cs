using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
   public class DbCustomerModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string BankId { get; set; } // Foreign key
        public DbBankModel Bank { get; set; }
        public double CurrentBalance { get; set; } = 1000;
        public virtual IList<DbTransactionModel> Transactions { get; set; }
    }
}
