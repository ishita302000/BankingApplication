using System;

namespace ATM.Models
{
    public class CreateAccount
    {
        public string name;
        public string password;
        public int currentbalance=1000 ;
        public CreateAccount(string name , string password)
        {
            this.password = password;
            this.name = name;
        }
    }
}
