using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Account : Parent
    {
        [Required]
        public double currentbalance { get; set; } = 1000;
        [Required]
        public string BankId
        {
            get; set;
        }
        public virtual IList<Transaction> Transactions { get; set; }
        public Bank Bank { get; set; }
       
    }
}
