using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
          // public Dictionary<string, List<string>> transactionhistory;
        // public Dictionary<string, string> userlogin;
        //    public Dictionary<string, Account> users; // Accounts

    //    public List<Account> Accounts;


        public string name;
        public int id;
        public Bank(string name, int id)
        {
            this.id = id;  // Generate it randomly
            this.name = name;
            this.Accounts = new List<Account>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
            }
}
