using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Account 
    {
        public string name { get; set; } // Name
        public string password { get; set; } // Password
        public double  currentbalance = 1000.00; // Balance
        public string AccountNo
        {
            get; set;
        }
        public string AccountId { get; set; }
        public string BankId
        {
            get; set;
         }
       
        public List<Transaction> Transactions ;
        public AccountStatus status { get; set; }
        private static int year = 2021;
        private DateTime currentDate { get; set; }

        public  Account(string name , string password , AccountStatus status=AccountStatus.Active)
        {
            this.password = password;
            this.name = name;
            this.status = status;
            this.Transactions = new List<Transaction>();
         //   users = new Dictionary<string, Account>();
          
            this.AccountNo = Convert.ToString(++year);

            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            AccountId = "";
            for (int i = 0; i < 3; i++)
            {
                AccountId += this.name[i];
            }
            AccountId += date;  // bankid
            this.status = status;
            
        }
    }
}
