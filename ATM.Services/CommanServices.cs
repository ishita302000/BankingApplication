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
        public Employee staff;
        readonly BankContext bankcontext = new BankContext();
        StaffServices staffServices = new StaffServices();
 
       
        public Account userlogin(string accid , string password , string bankid)    // user
        {
            Account user = null;
            Bank bank;

            try
            {
                bank = staffServices.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist"); // use constants
                }
                foreach (var account in bankcontext.Account.Where(account => account.Id == accid & account.Password == password))
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
    public Employee Stafflogin(string id, string password , string bankid)    // user
        {
            Employee user = null;
            try
            {
                bank = staffServices.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                foreach (var account in bankcontext.Staff.Where(account => account.Id == id & account.Password == password))
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
            foreach (Employee account in bankcontext.Staff)
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
          
            foreach( Account account in bankcontext.Account)
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
                bank = staffServices.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }

                foreach (var account in bankcontext.Account.Where(account => account.Name == username))
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
            Account account = bankcontext.Account.FirstOrDefault(a => a.Id == userid);

            return account.Transactions;      // check 
        }

        public bool StaffAccountExit(string username , string bankid)    // user
        {
            // var a = Account.userlogin.ContainsKey(username);
            //  return bank.user.ContainsKey(username);
            Employee user = null;
            try
            {
                bank = staffServices.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                // use isExist which return true/false  
                foreach (var account in bankcontext.Staff.Where(account => account.Name == username))
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

