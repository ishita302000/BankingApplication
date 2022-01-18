using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Bank
    {
      
        public string BankName  { get; set;  }  
        public string Id { get; set; }
        public DateTime CreatedOn { get; set;}
        public string CreatedBy { get; set; }
        public string BankId { get; set; }
        public virtual IList<Customer> Accounts { get; set; }
        public virtual IList<Employee> StaffAccount { get; set; }
        public virtual IList<Currency> Currencies { get; set; } 
        public virtual IList<Transaction> Transactions { get; set; }
        public double RTGSsameBank { get; set; } = 0;
        public double RTGSdifferentBank { get; set; } = .02;
        public double IMPSsameBank {  get; set; } = 0.5;
        public double IMPSdifferentBank { get; set; } = .06;
        const string DefaultCurrency = "INR";  
        public string Countrycode = DefaultCurrency;

           
     }
}
