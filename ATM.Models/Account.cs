﻿using System;
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
        public string Txn { get; set; }

        public List<string> transactionhistory;
     //   public Dictionary<string, string > userlogin;   // id 
        private static int x = 2021;
        private DateTime currentDate;

        public  Account(string name , string password , string Id)
        {
            this.password = password;
            this.name = name;
            this.transactionhistory = new List<string>();
         //   users = new Dictionary<string, Account>();
        //  this.userlogin = new Dictionary<string, string>();
            this.AccountNo = Convert.ToString(++x);
            currentDate = DateTime.Now;
            String date = currentDate.ToShortDateString();
            AccountId = "";
            for (int i = 0; i < 3; i++) 
                AccountId += this.name;
            AccountId += date;
        }

      
    }
}
