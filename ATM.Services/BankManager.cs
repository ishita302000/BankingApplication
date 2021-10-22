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
   //     Account Account;
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

        public void CreateBank(string name)
        {
            Bank bank = new Bank
            { };
        }
        public int deposit( int amount, string username)
        {
    //        var account = bank.Accounts.FirstOrDefault(m=>m.Id == accountId);
     //       return amount.currentBalance += amount;
           return bank.Accounts[username].currentbalance += amount;
           
        }
        public int withdraw(int amount, string accountId)
        {
              //  var account = bank.Accounts.FirstOrDefault(m => m.Id == accountId);
            //   return amount.currentbalance -= amount;
             return bank.Accounts[accountId].currentbalance += amount;
           
        }
        public bool transfer(int amount, string accountId1, string accountId2)
        {
            //   Account account1 = bank.Accounts.FirstOrDefault(m => m.Id == accountId1);  
            // if (account1 == null)
            //   {
            //     throw new UserNotFoundException();
            //  }
            //   Account account2 = bank.Accounts.FirstOrDefault(m => m.Id == accountId2);
            // if (account2 == null)
            //  {
            //    throw new UserNotFoundException();
            //}
            //  var bal = accountId2.currentbalance += amount;
            bank.Accounts[accountId1].currentbalance -= amount;
            if(bank.Accounts.ContainsKey(accountId2))
            {
                deposit( amount , accountId2);
                //addtransaction(accountId1 , " Id recieved " + amount + " from account " + accountId2);
                addtransaction( accountId1, "recieved " + amount + " from " + accountId2);

            }
            return true;

        }
        public void addaccount(string username, string password, string id)
        {
            //    bank.Accounts.Add(new List<username>());   // check
            Account newAccount = new Account(username, password, id);
            bank.Accounts.Add( username , newAccount); // list
            newAccount.userlogin.Add(username, password);  //
        }
        public void addtransaction(string accountId, string transaction)
        {
            //  Account account = bank.Accounts.FirstOrDefault(a => a.Id == accountId);
            //   if (account == null)
            //   {
            //     throw new UserNotFoundException();
            //}
            bank.Accounts[accountId].transactionhistory.Add(transaction);
         //   account.transactionhistory.Add(transaction);
            //    Account.transactionhistory[id].Add(transaction);
            // account1.transactionhistory[account1].Add(transaction);
        }
        public bool login(string username, string password )
        {
            //var somthing = Account.userlogin[username];
            if( bank.Accounts[username].password == password)
            {
            //    if( bank.Accounts[username].AccountId == accountId)
                    return true;
            }
            return false;
        }
        public bool checkId( string username , string accountId)
        {
            //   if ( bank.Accounts[username].AccountId == accountId)
            // {
            //   return true;
            //}
            //return false;
            return bank.Accounts[username].AccountId == accountId;

        }
        public bool AccountExit(string username)
        {
            // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
        /*    foreach (Account account in bank.Accounts)
            {
                if (account.userlogin.ContainsKey(username))
                {
                    return true;
                }
            }
        */
            return bank.Accounts.ContainsKey(username);
        }
        public List<string> GettransactionHistory(string username, string id)
        {
            //   Account account = bank.Accounts.FirstOrDefault(a => a.Id == id);
            // foreach (string transaction in account.transactionhistory)
            //   {
            //     Console.WriteLine(transaction);
            //}
            return bank.Accounts[username].transactionhistory;
        }
       
    }
}

