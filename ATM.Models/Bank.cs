using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
       public Dictionary<string , Account> Accounts;
      //   public Dictionary<string, string> user;  // coustomers
        public string name;
        public string Id;
        private readonly DateTime currentDate;
        public Bank(string name, int id)
        {
           this.name = name;
            //    this.transactionhistory = new Dictionary<string, List<string>>();
            //    this.user = new Dictionary<string, string>();
            this.Accounts = new Dictionary<string, Account>();
            currentDate = DateTime.Now;
            string date = currentDate.ToShortDateString();
            Id = "";
            for(int i=0;i<3;i++)
            {
                Id += this.name;
            }
            Id += date;
        }
       // public List<Account> Accounts { get; set; }
            }
}
