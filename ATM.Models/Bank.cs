using System.Collections.Generic;

namespace ATM.Models
{
    public class Bank
    {
        public Dictionary<string , List<string>> transactionhistory;
         public Dictionary<string, string> user;
        public string name;
        public int id;
        public Bank(string name, int id)
        {
           this.id = id;
           this.name = name;
            transactionhistory = new Dictionary<string, List<string>>();
            user = new Dictionary<string, string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
            }
}
