using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Password { get; set;}
        public string  BankId{ get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string CustomerId { get; set; }
        public double CurrentBalance { get; set; } = 1000;
        public virtual IList<Transaction> Transactions { get; set; }
       
        
    }
}
