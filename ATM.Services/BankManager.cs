using System;
using System.Collections.Generic;
using ATM.Models;

namespace ATM.Services
{

    //login
    // addaccount
    //trasactionhistory -- add transaction 
    //username exit 
    //userpassword exit
    //deposit
    //withdrawl
    public class BankManager
    {
        int serialnumber;
       Bank bank;
         public BankManager(Bank b)
        {
            this.bank = b;
        }

        public BankManager()
        {
        }

   /*     public int deposit( int balance)
        {
          ///  balance = balance+ BankManager.deposit;
            return balance;
        }
        public int withdraw(int balance)
        {
            return balance;
        }
*/
        public void  addaccount(string username , string pasword)
        {
            bank.user.Add(username, pasword);    // dic of user(bank)--username , password is added to the list 
            bank.transactionhistory.Add(username, new List<String>());
        }
        public List<string> transactionHistory(string username)
        {
            return bank.transactionhistory[username];
        }
        public void addtransaction(string username , string transaction)
        {
            bank.transactionhistory[username].Add(transaction);
        }
        public bool login(string username , string password )
        {
            return bank.user[username] == bank.user[password];
        }
        public bool checkusername(string username)
        {
            return bank.user.ContainsKey(username);
        }
        public bool checkpassword(string username ,string password)
        {
            return bank.user[username] == password;
        }
       // public bool checkaccount()
        //{

      //  }

    }
}
