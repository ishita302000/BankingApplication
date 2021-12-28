using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Bank
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
        [Required]
        public string Name
        {
            get; set;  }
        [Required]
        public string Password
        {
            get; set;
        }
        [Key]
        [Required]
        public string Id;
        [Required]
        public DateTime dateTime { get; set;
        }
        public virtual IList<Account> Accounts { get; set; }
    
        public virtual IList<StaffAccount> StaffAccount { get; set; }
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

        public Bank(string Name)
        {
            this.Name = Name;
            DateTime currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            // set accountId
            this.Id = "";
            for (int i = 0; i < 3; i++) this.Id += this.Name[i];
            Id += date;
        }          
     }
}
