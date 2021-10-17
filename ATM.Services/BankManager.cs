using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.Models.Exceptions;

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
        Account Account;
        public BankManager(string name, int id)
        {
            this.bank = new Bank(name, id);
        }

      /*  public BankManager(Bank bank)
        {
            this.bank = bank;
        }
       /* public BankManager(string name, string password, int id)
        {
            this.Account = new Account(name, password, id);
        }
       */
        public double deposit(int amount, double accountId)
        {
            var account = bank.Accounts.FirstOrDefault(m => m.Id == accountId);  //lamda
            return account.currentbalance += amount;

            //bank.users[username].currentbalance += amount;    // arr[i]  2 3 4
            //return bank.users[username].currentbalance;
        }

        public double withdraw(int amount, double accountId)
        {
            var account = bank.Accounts.FirstOrDefault(m => m.Id == accountId);
            //   return amount.currentbalance -= amount;
            return account.currentbalance -= amount;

        }
        public double transfer(int amount, int accountId1, int accountId2)
        {
            Account account1 = bank.Accounts.FirstOrDefault(m => m.Id == accountId1);
            if (account1 == null)
            {
                throw new UserNotFoundException();
            }
            Account  account2 = bank.Accounts.FirstOrDefault(m => m.Id == accountId2);
            if(account2 ==null)
            {
                throw new UserNotFoundException();
            }
            //  var bal = accountId2.currentbalance += amount;
            account2.currentbalance += amount;
            return account1.currentbalance -= amount;

        }
        public void addaccount(string username, string password, int id)
        {
            //    bank.Accounts.Add(new List<username>());   // check
            Account newAccount = new Account(username, password, id);
            bank.Accounts.Add(newAccount); // list
            newAccount.userlogin.Add(username, password);  //
        }
        public void addtransaction(string username, string transaction, int accountId)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account==null)
            {
                throw new UserNotFoundException();
            }
            account.transactionhistory.Add(transaction);
            //    Account.transactionhistory[id].Add(transaction);
           // account1.transactionhistory[account1].Add(transaction);
        }
      public bool login(string username, string password)
        {
        //var somthing = Account.userlogin[username];
            return Account.userlogin[username] == password;
        }
        public bool checkusername(string username)
        {
           // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            foreach (Account account in bank.Accounts)
            {
                if (account.userlogin.ContainsKey(username))
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkpassword(string username, string password)
        {
            foreach (Account account in bank.Accounts)
            {
                if (account.userlogin.ContainsKey(username))
                {
                    return account.userlogin[username] == password;
                }
            }
            return false;
        }
      
        public void transactionHistory(string username , int id)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.Id == id);
            foreach (string transaction in account.transactionhistory)
            {
                Console.WriteLine(transaction);
            }
        }
  

    }
}

