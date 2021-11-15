using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Account
    {
        public string name; // Name
        public string password; // Password
        public double  currentbalance = 1000.00; // Balance
        public string AccountNo;
        public string AccountId;
        public string BankId;
       
        public List<Transaction> Transactions ;
        public AccountStatus status;
        private static int year = 2021;
        private DateTime currentDate;

        public  Account(string name , string password , AccountStatus status=AccountStatus.Active)
        {
            this.password = password;
            this.name = name;
            this.status = status;
            this.Transactions = new List<Transaction>();
         //   users = new Dictionary<string, Account>();
          
            this.AccountNo = Convert.ToString(++year);
            currentDate = DateTime.Now;
            String date = currentDate.ToShortDateString();
     //       this.AccountId = "xyz";
            AccountId = "";
            for (int i = 0;i<3; i++) 
                AccountId += this.name;
            AccountId += date;  // ish1203
            
        }
    }
}
