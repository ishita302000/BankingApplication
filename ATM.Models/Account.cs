using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Account
    {
        public string name; // Name
        public string password; // Password
        public int  currentbalance = 1000; // Balance
        public string AccountNo;
        public string AccountId;
        public string BankId;
        public Dictionary<string, string> userLogin;
        public List<string> transactionhistory ;
        public AccountStatus status;
        private static int year = 2021;
        private DateTime currentDate;

        public  Account(string name , string password , AccountStatus status=AccountStatus.Active)
        {
            this.password = password;
            this.name = name;
            this.status = status;
            this.transactionhistory = new List<string>();
         //   users = new Dictionary<string, Account>();
          this.userLogin = new Dictionary<string, string>();
            this.AccountNo = Convert.ToString(++year);
            currentDate = DateTime.Now;
            String date = currentDate.ToShortDateString();
     //       this.AccountId = "xyz";
            AccountId = "";
            for (int i = 0; i < 3; i++) 
                AccountId += this.name;
            AccountId += date;  // ish1203
            this.AccountId = AccountId;
        }
    }
}
