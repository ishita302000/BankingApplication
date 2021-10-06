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
        Bank bank;
         public BankManager(string name , int id)
        {
            this.bank = new Bank( name , id);
        }

        public BankManager(Bank bank)
        {
            this.bank = bank;
        }

        public double deposit( double amount , string username)
        {
            bank.users[username].currentbalance += amount;    // arr[i]  2 3 4
            return bank.users[username].currentbalance;
        }
        public double withdraw(double amount , string username)
        {
            bank.users[username].currentbalance -= amount;
            return bank.users[username].currentbalance;
        }
        public double transfer(double amount, string accno , string username)
        {
            bank.users[username].currentbalance -= amount;
           // bank.users[]
            return bank.users[username].currentbalance;
        }

        public void  addaccount(string username , string pasword)
        {
            bank.userlogin.Add(username, pasword);    // dic of user(bank)--username , password is added to the list 
            bank.transactionhistory.Add(username, new List<String>());
            bank.users.Add(username, new Account(username,pasword));
        }
    /*    public List<string> transactionHistory(string username)
        {
            return bank.transactionhistory[username];
        }
    */
        public void addtransaction(string username , string transaction)
        {
            bank.transactionhistory[username].Add(transaction);
        }
        public bool login(string username , string password )
        {
            return bank.userlogin[username] == bank.userlogin[password];
        }
        public bool checkusername(string username)
        {
            var a = bank.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            return a;
        }
        public bool checkpassword(string username ,string password)
        {
            return bank.userlogin[username] == password;
        }
        public void transactionHistory(string username)
        {
            foreach (string transaction in bank.transactionhistory[username])
            {
                Console.WriteLine(transaction);
            }
        }

    }
}
