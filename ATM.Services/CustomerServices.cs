using ATM.Models;
using ATM.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Services
{
   public class CustomerServices // write Interfaces which inherit all the methods inside this service
    {
        Bank bank;

        public CustomerServices( string bankname , string countrycode)
        {
            this.bank = new Bank(bankname , countrycode);
        }

        public void deposit(double amount, Account user, string currentycode, string bankid)  // static
        {
            try {
               
                user.currentbalance += (amount * Currency.curr[currentycode]);
                Transaction transaction = new Transaction(user.AccountId, user.AccountId, amount, DateTime.Now, TransactionType.Credited, bankid, bankid);
                user.Transactions.Add(transaction);
               // return user.currentbalance;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        public bool withdraw(double amount, string accountId , Account user ,string bankid)
        {
            if(user.currentbalance >= amount)
            { 
           
            //   return amount.currentbalance -= amount;
            user.currentbalance -= amount;
            Transaction transaction = new Transaction( user.AccountId , user.AccountId , amount , DateTime.Now , TransactionType.Debited  , bankid , bankid);
            user.Transactions.Add(transaction);
            return true;
            }
            return false;
        }
        public bool transfer(double amount, string accountId1, string accountId2 , string SenderBankId , string RecieverBankId , string choice)
        {
         //   Bank SenderBank = null;
            Bank RecieverBank = null;
            try
            {
                foreach(var i in BankList.Banks)
                {
                    if(i.BankId==SenderBankId)
                    {
                        bank = i;  // senderbank
                    }
                    if(i.BankId==RecieverBankId)
                    {
                        RecieverBank =i;
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
                Account account1 = bank.Accounts.FirstOrDefault(m => m.AccountId == accountId1);
                if (account1 == null)
                {
                    throw new UserNotFoundException();
                }
                Account account2 = bank.Accounts.FirstOrDefault(m => m.AccountId == accountId2);
                if (account2 == null)
                {
                    throw new UserNotFoundException();
                }
                if (account1.currentbalance >= amount + charge)
                {
                    account1.currentbalance -= amount + charge;
                    account2.currentbalance += Math.Round(amount * (double)(Currency.curr[bank.Countrycode] / Currency.curr[RecieverBank.Countrycode]), 2);
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
        public double DeductCharge(double amount , double percent )
        {
            return (double)Math.Round(amount*percent , 2);
        }
    /*    public void addtransaction(string senderId, string receiverId, double amount, TransactionType transactionType , string senderbankid,string recieverbankid)
        {
            DateTime datetime = DateTime.Now;
            Transaction transaction = new Transaction( senderId , receiverId,   amount, datetime, transactionType , senderbankid , recieverbankid);
            var acc = GetAccount(senderId);
            acc.Transactions.Add(transaction);
        }
    
        public List<Transaction> GettransactionHistory(string username, string userid)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.AccountId == userid);
           
            return account.Transactions;
        }
    */
        public Account GetAccount(string accId)
        {
            foreach (var acc in bank.Accounts)
            {
                if (acc.AccountId == accId) return acc;
            }
            return null;
        }

    }
    }














