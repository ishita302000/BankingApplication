using ATM.Models;
using ATM.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Services
{
   public class AccountServices
    {
        Bank bank;

        public AccountServices( string name)
        {
            this.bank = new Bank(name);
        }
       
        public  int deposit(int amount, string accountId)  // static
        {
            Account account = bank.Accounts.FirstOrDefault(m => m.AccountId == accountId);
            account.currentbalance += amount;

            return account.currentbalance;
        }
        public int withdraw(int amount, string accountId)
        {
            var account = bank.Accounts.FirstOrDefault(m => m.AccountId == accountId);
            //   return amount.currentbalance -= amount;
            return account.currentbalance -= amount;

        }
        public bool transfer(int amount, string accountId1, string accountId2)
        {
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
            var bal = account2.currentbalance += amount;
            //    bank.Accounts[accountId1].currentbalance -= amount;
            //  if(bank.Accounts.ContainsKey(accountId2))
            //{
            //  deposit( amount , accountId2);
            //addtransaction(accountId1 , " Id recieved " + amount + " from account " + accountId2);
            //addtransaction( accountId1, "recieved " + amount + " from " + accountId
            return true;

        }
        public void addtransaction(string senderId, string receiverId, double amount, TransactionType transactionType)
        {
            //  Account account = bank.Accounts.FirstOrDefault(a => a.Id == accountId);
            //   if (account == null)
            //   {
            //     throw new UserNotFoundException();
            //}
            DateTime datetime = DateTime.Now;
            Transaction transaction = new Transaction( senderId , receiverId,   amount, datetime, transactionType);
            var acc = GetAccount(senderId);
            acc.Transactions.Add(transaction);
        }
        public List<Transaction> GettransactionHistory(string username, string userid)
        {
            Account account = bank.Accounts.FirstOrDefault(a => a.AccountId == userid);
           
            return account.Transactions;
        }

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

