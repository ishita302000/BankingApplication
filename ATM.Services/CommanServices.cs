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
    public class CommanServices
    {
        public Bank bank;
        public Staff staff;
     

       

     /*   public List<string> BankList()
        {
            BankList.Add("Axis Bank");
            BankList.Add("HDFC Bank");
            BankList.Add("SBI Bank");
            BankList.Add("Kotak Bank");
            return BankManager.BankList;
        }*/
     
        public string addaccount(string username, string accountId)
        {
               // bank.Accounts.Add(new List<username>());   // check
            Account newAccount = new Account(username, accountId);
            //    bank.Accounts.Add( username , newAccount); // list
            //  newAccount.userLogin.Add(username, accountId );  //
            bank.Accounts.Add(newAccount);
            return newAccount.AccountId;
        }
     
        public Account userlogin(string accid , string password , string bankid )    // user
        {
            Account user = null;

            try
            {
                bank = StaffServices.FindBank(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                foreach (var account in bank.Accounts.Where(account => account.AccountId == accid & account.password == password))
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
                foreach (var account in bank.StaffAccount.Where(account => account.StaffId == id & account.Password == password))
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

                foreach (var account in bank.Accounts.Where(account => account.name == username))
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

        public List<Transaction> GettransactionHistory(string username, string userid)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.AccountId == userid);

            return account.Transactions;
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

