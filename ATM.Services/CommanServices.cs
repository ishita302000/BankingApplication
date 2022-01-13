using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.DbModels;

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
        public DbBankModel bank;
        public Employee staff;
        readonly BankContext bankcontext = new BankContext();
        DbServices staffServices = new DbServices();
 
       
        public DbCustomerModel userlogin(string accid , string password , string bankid)    
        {
            DbCustomerModel user = null;

            try
            {
               
                bank = staffServices.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist"); 
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
    public DbEmployeeModel Stafflogin(string id, string password , string bankid)    // user
        {
            DbEmployeeModel user = null;
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
        public double viewbalance(DbCustomerModel user)
        {
            return user.CurrentBalance;
        }



    }
}

