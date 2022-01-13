using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Services
{
   public class CustomerServices // write Interfaces which inherit all the methods inside this service
    {
        Bank bank;
        readonly BankContext bankcontext = new BankContext();

        public void deposit(double amount, DbCustomerModel user, string currentycode, string bankid)  // static
        {
            try
            {
               user.CurrentBalance += (amount * bankcontext.Currency.FirstOrDefault(c=>c.Code == currentycode).ExchangeRate);  // check
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        public bool withdraw(double amount, string accountId , DbCustomerModel user , string bankid)
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
         Bank SenderBank;
         Bank RecieverBank;
            try
            {
                using (BankContext bankContext = new BankContext())
                {
                    SenderBank = bankContext.Bank.FirstOrDefault(b => b.Id == );
                    RecieverBank = bankContext.Bank.FirstOrDefault(b => b.Id == );
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
                        charge = DeductCharge(amount, bank.RTGSsameBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount, bank.IMPSsameBank);
                    }
                }
                else
                {
                    if (choice == "1")
                    {
                        charge = DeductCharge(amount, bank.RTGSdifferentBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount, bank.IMPSdifferentBank);
                    }

                }
                DbCustomerModel account1 = bankcontext.Account.FirstOrDefault(m => m.Id == accountId1);
                if (account1 == null)
                {
                    throw new UserNotFoundException();
                }
                DbCustomerModel account2 = bankcontext.Account.FirstOrDefault(m => m.Id == accountId2);
                if (account2 == null)
                {
                    throw new UserNotFoundException();
                }
                if (account1.CurrentBalance >= amount + charge)
                {
                    account1.CurrentBalance -= amount + charge;
                    account2.CurrentBalance += Math.Round(amount * (bankcontext.Currency.FirstOrDefault(a => a.Code == senderbankcurrencycode).ExchangeRate));
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














