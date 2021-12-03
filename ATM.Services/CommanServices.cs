using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.Models.Exceptions;


namespace ATM.Services // write Interfaces which inherit all the methods inside this service
{

    //login
    // addaccount
    //trasactionhistory -- add transaction 
    //username exit 
    //userpassword exit
    //deposit
    //withdrawl
    public class CommanServices
    {
        public Bank bank;
        public Staff staff;
 
        public string addaccount(string username, string accountId, string password , double balance , string bankid)
        {
            // bank.Accounts.Add(new List<username>());   // check
            Account newAccount = new Account {
                Name = username,
                Id = accountId,
                Password = password,
                 currentbalance = balance,
                 BankId = bankid,

            };
            //    bank.Accounts.Add( username , newAccount); // list
            //  newAccount.userLogin.Add(username, accountId );  //
            bank.Accounts.Add(newAccount);
            return newAccount.Id;
        }
     
        public Account userlogin(string accid , string password , string bankid )    // user
        {
            Account user = null;

            try
            {
                bank = StaffServices.FindBank(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist"); // use constants
                }
                foreach (var account in bank.Accounts.Where(account => account.Id == accid & account.Password == password))
                {
                    user = account;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return user;
        }
    public Staff Stafflogin(string id, string password , string bankid)    // user
        {
            Staff user = null;
            try
            {
                bank = StaffServices.FindBank(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                foreach (var account in bank.StaffAccount.Where(account => account.Id == id & account.Password == password))
                {
                    user = account;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public bool StaffcheckId(string accountId)    // user
        {
            foreach (Staff account in bank.StaffAccount)
            {
                if (account.Id == accountId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UsercheckId( string accountId)
        {
          
            foreach( Account account in bank.Accounts)
            {
                if(account.Id==accountId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UserAccountExit(string username , string bankid)    // user
        {
            // var a = Account.userlogin.ContainsKey(username);
            Account user = null;
            try
            {
                bank = StaffServices.FindBank(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }

                foreach (var account in bank.Accounts.Where(account => account.Name == username))
                {
                    user = account;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public IList<Transaction> GettransactionHistory(string username, string userid)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.Id == userid);

            return account.Transactions;      // check 
        }

        public bool StaffAccountExit(string username , string bankid)    // user
        {
            // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            Staff user = null;
            try
            {
                bank = StaffServices.FindBank(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                // use isExist which return true/false  
                foreach (var account in bank.StaffAccount.Where(account => account.Name == username))
                {
                    user = account;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
        public double viewbalance(Account user)
        {
            return user.currentbalance;
        }



    }
}

