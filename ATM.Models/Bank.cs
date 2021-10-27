using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
        public Dictionary<string, Account> Accounts; // accounts of customers
        public Dictionary<string, Staff> StaffAccount;  
        public string name;
        public string BankId;
        private readonly DateTime currentDate;
        public double RTGSsameBank;
        public double RTGSdifferentBank;
        public double IMPSsameBank;
        public double IMPSdifferentBank;
         
        // currency part left 
        public Bank(string name, int id)
        {
           this.name = name;
            //    this.transactionhistory = new Dictionary<string, List<string>>();
            //    this.user = new Dictionary<string, string>();
            this.Accounts = new Dictionary<string, Account>();
            this.StaffAccount = new Dictionary<string, Staff>();
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            BankId = "";
            for(int i=0;i<3;i++)
            {
                BankId += this.name;
            }
            BankId += date;  // bankid
            this.RTGSsameBank = 0;    //0%
            this.RTGSdifferentBank = 0; // 2%
            this.IMPSsameBank = 0;    //5%
            this.IMPSdifferentBank = 0;   // 6%
        }       
     }
}
