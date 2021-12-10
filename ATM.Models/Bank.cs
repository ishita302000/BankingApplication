using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank : Parent
    {
        //   private const double V = 0.05;
      //  public string Id;
   /*     public Bank()
        {
        Id="";
       for(int i=0;i<3;i++)
            { Id+=Name[i];
            }
        Id+=date;
        }
     */
        public virtual IList<Account> Accounts { get; set; } // accounts of customers
        public virtual IList<Staff> StaffAccount { get; set; }
        public virtual IList<Currency> Currencies { get; set; }
 
        public virtual IList<Transaction> transactions { get; set; }
      
      
        public double RTGSsameBank { get; set; } = 0;
        public double RTGSdifferentBank { get; set; } = .02;
        public double IMPSsameBank
        {
            get; set;
        } = 0.5;
        public double IMPSdifferentBank { get; set; } = .06;
        const string DefaultCurrency = "INR"; // maintain constants saparately 
        public string Countrycode = DefaultCurrency;
           
     }
}
