using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.DbModels;
using ATM.Services.IServices;
using AutoMapper;
using System;
using System.Linq;

namespace ATM.Services
{
    public class CustomerServices : ICustomerServices // write Interfaces which inherit all the methods inside this service
      {
        private readonly BankContext _bankContext;
        private readonly IMapper _mapper;
        public CustomerServices(BankContext bankContext ,  IMapper mapper)
        {
            _mapper = mapper;
            _bankContext = bankContext;
        }

        public void Deposit(double amount, Customer user, string currentycode)  // static
        {
            try
            {
               user.CurrentBalance += (amount * _bankContext.Currency.FirstOrDefault(c=>c.Code == currentycode).ExchangeRate);  // check
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        public bool Withdraw(double amount,  Customer user )
        {
            if(user.CurrentBalance >= amount)
            { 
            //   return amount.currentbalance -= amount;
                 user.CurrentBalance -= amount;   
            }
            return false;
        }
        public bool transfer(double amount, string accountId1, string accountId2 , string SenderBankId , string RecieverBankId , string choice , string senderbankcurrencycode)
        {
         DbBankModel SenderBank;
         DbBankModel RecieverBank;
            try
            {
                using ( _bankContext)
                {
                    SenderBank = _bankContext.Bank.FirstOrDefault(b => b.Id == SenderBankId);   //// check 
                    RecieverBank = _bankContext.Bank.FirstOrDefault(b => b.Id ==RecieverBankId );   // check
                    if (SenderBank == null || RecieverBank == null)
                    {
                        throw new BankDoesnotExistException();
                    }
                }
                
                double charge;
                if(SenderBankId==RecieverBankId)
                {
                    if( choice =="1")
                    {
                        charge = DeductCharge(amount, SenderBank.RTGSsameBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount, SenderBank.IMPSsameBank);
                    }
                }
                else
                {
                    if (choice == "1")
                    {
                        charge = DeductCharge(amount, RecieverBank.RTGSdifferentBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount,  RecieverBank.IMPSdifferentBank);
                    }

                }
                DbCustomerModel account1 = _bankContext.Account.FirstOrDefault(m => m.CustomerId == accountId1);
                if (account1 == null)
                {
                    throw new UserNotFoundException();
                }
                DbCustomerModel account2 = _bankContext.Account.FirstOrDefault(m => m.CustomerId == accountId2);
                if (account2 == null)
                {
                    throw new UserNotFoundException();
                }
                if (account1.CurrentBalance >= amount + charge)
                {
                    account1.CurrentBalance -= amount + charge;
                    account2.CurrentBalance += Math.Round(amount * (_bankContext.Currency.FirstOrDefault(a => a.Code == senderbankcurrencycode).ExchangeRate));
                    return true;
                }
             //   account2.currentbalance += amount;
             //   account1.currentbalance -= amount;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Transfer: {0}", ex.Message);
            }
            return false;
        }    
        public double DeductCharge(double amount, double percent)
        {
            return (double)Math.Round(amount * percent, 2);
        }
    }
  }














