using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.DbModels;
using ATM.Services.IServices;
using AutoMapper;

namespace ATM.Services // write Interfaces which inherit all the methods inside this service
{
    //login
    // addaccount
    //trasactionhistory -- add transaction 
    //username exit 
    //userpassword exit
    //deposit
    //withdrawl
    public class CommanServices : ICommanServices
    {
        private readonly BankContext _bankContext;
        private readonly IMapper _mapper;
        private  IDbServices dbservice_;
        public CommanServices(BankContext bankContext , IMapper mapper , IDbServices dbServices)
        {
            _bankContext = bankContext;
            _mapper = mapper;
            dbservice_ = dbServices;
        }
        
        public Customer userlogin(string accid , string password , string bankid)    
        {
            DbCustomerModel user = null;

            try
            {
               
                Bank bank = dbservice_.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist"); 
                }
                foreach (var account in _bankContext.Account.Where(account => account.CustomerId == accid & account.Password == password))
                {
                    user = account;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return _mapper.Map<Customer>(user);
        }
        public Employee Stafflogin(string id, string password , string bankid)    // user
          {
            DbEmployeeModel user = null;
            try
            {
              Bank bank = dbservice_.GetBankById(bankid);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                foreach (var account in _bankContext.Staff.Where(account => account.EmployeeId == id & account.Password == password))
                {
                    user = account;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _mapper.Map<Employee>(user);
        }
        public double viewbalance(Customer user)
        {
            return user.CurrentBalance;
        }
    }
}

