using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Account : Parent
    {
 
        public double currentbalance { get; set; } = 1000;
        public string BankId
        {
            get; set;
        }
        public virtual IList<Transaction> Transactions { get; set; }
        public Bank Bank { get; set; }
       
    }
}
