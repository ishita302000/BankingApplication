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
        public string Id { get; set; }
        public double CurrentBalance { get; set; } = 1000;
        public virtual IList<Transaction> Transactions { get; set; }
    }
}
