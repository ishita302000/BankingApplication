using System;
using System.Collections.Generic;

namespace ATM.Models
{
    public class Account
    {
        public string name; // Name
        public string password; // Password
        public int  currentbalance = 1000; // Balance
        public List<string> transactionhistory;
        public Dictionary<string, string > userlogin;

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Id { get; set; }

      //  public bool IsActive { get; set; }

        public  Account(string name , string password , int Id)
        {
            this.password = password;
            this.name = name;
            this.Id = Id;

            this.transactionhistory = new List<string>();
         //   users = new Dictionary<string, Account>();
          this.userlogin = new Dictionary<string, string>();
        }
    }
}
