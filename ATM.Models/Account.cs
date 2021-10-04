using System;

namespace ATM.Models
{
    public class Account
    {
        public string name;
        public string password;
        public double currentbalance=1000.00 ;
        public Account(string name , string password)
        {
            this.password = password;
            this.name = name;
        }
    }
}
