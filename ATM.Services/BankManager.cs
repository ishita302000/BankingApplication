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
   
        public BankManager(string name, string id)
        {
            this.bank = new Bank(name, id);
        }
     
        public string addaccount(string username, string accountId)
        {
               // bank.Accounts.Add(new List<username>());   // check
            Account newAccount = new Account(username, accountId);
        //    bank.Accounts.Add( username , newAccount); // list
            newAccount.userLogin.Add(username, accountId );  //
            return newAccount.AccountId;
        }
     
        public bool userlogin(string username, string password )    // user
        {
            
            foreach(Account account in bank.Accounts)
            {
                if( account.name == username)
                {
                    if(account.password==password)
                    {
                        return true;
                    }
                }
            }
            return false;
           
        }
        public bool StaffcheckId(string accountId)    // user
        {
            foreach (Staff account in bank.StaffAccount)
            {
                if (account.StaffId == accountId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UsercheckId( string accountId)
        {
            //   if ( bank.Accounts[username].AccountId == accountId)
            // {
            //   return true;
            //}
            //return false;
            //   return bank.Accounts[username].AccountId == accountId;
            //    return bank.Accounts[username].userlogin[] == accountId;

          //  var result = bank.Accounts.FirstOrDefault(a => a.AccountId == accountId);
        //    if(result)
        //    {
         //       return true;
        //    }
         //   return false;
            foreach( Account account in bank.Accounts)
            {
                if(account.AccountId==accountId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UserAccountExit(string username)    // user
        {
            // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            foreach (Account account in bank.Accounts)
            {
                if (account.userLogin.ContainsKey(username))
                {
                    return true;
                }
            }
            return false;
           // return bank.Accounts.Contains(username);
        }
        public bool StaffAccountExit(string username)    // user
        {
            // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            foreach (Staff account in bank.StaffAccount)
            {
                if (account.stafflogin.ContainsKey(username))
                {
                    return true;
                }
            }
            return false;
            // return bank.Accounts.Contains(username);
        }
    
        public List<string> GettransactionHistory(string username, string id)
        {
              Account account = bank.Accounts.FirstOrDefault(a => a.AccountId == id);
             foreach (string transaction in account.transactionhistory)
               {
                 Console.WriteLine(transaction);
            }
            return bank.Accounts.;
        }
       
    }
}

