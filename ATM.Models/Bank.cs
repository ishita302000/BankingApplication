﻿using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
        //   private const double V = 0.05;
        public List<Account> Accounts; // accounts of customers
        public List<Staff> StaffAccount;
        public string name { get; set; }
        public string BankId { get; set; }
        public string Branch { get; set; } // use list as we have list of branches
        private readonly DateTime currentDate;
        public double RTGSsameBank { get; set; }
        public double RTGSdifferentBank { get; set; }
        public double IMPSsameBank
        {
            get; set;
        }
        public double IMPSdifferentBank { get; set; }
        const string DefaultCurrency = "INR"; // maintain constants saparately 
        public string Countrycode = DefaultCurrency;
        // currency part left 

        public Bank(string name , string Countrycode)
        {
           this.name = name;
            //    this.transactionhistory = new Dictionary<string, List<string>>();
            //    this.user = new Dictionary<string, string>();
            this.Accounts = new List<Account>();
            this.StaffAccount = new List<Staff>();
            this.Countrycode = Countrycode;
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            BankId = "";
            for(int i=0;i<3;i++) // use substring
            {
                BankId += this.name[i];
            }
            BankId += date;  // bankid
            this.RTGSsameBank = 0;    //0%
            this.RTGSdifferentBank = .02; // 2%
            this.IMPSsameBank = .05;    //5%
            this.IMPSdifferentBank = 0.06;   // 6%
        }       
     }
}
