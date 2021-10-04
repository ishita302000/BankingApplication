using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
   public class Bank
    {
        public Dictionary<string , List<string>> transactionhistory;
         public Dictionary<string, string> userlogin;
        public Dictionary<string , Account> users;
        public string name;
        public int  id;
        
        public Bank( string name , int id )
        {
           this.id = id;
           this.name = name;
            transactionhistory = new Dictionary<string, List<string>>();
            users = new Dictionary<string, Account>();
            userlogin = new Dictionary<string, string>();
        }
    }
}
