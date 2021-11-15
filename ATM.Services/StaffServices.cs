using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ATM.Models;
using ATM.Models.Enums;

namespace ATM.Services
{
   public class StaffServices 
    {
       public   Bank bank;
      public  Staff staff;
    
        public bool revertTransaction()
        {
            return false;
        }
        public Account checkAccount(string bankid, string id)
        {
            Account user = null;
            try
            {
                bank = FindBank(bankid);
                if(bank==null)
                {
                    throw new Exception("Bank doesn't exist! ");
                }
                foreach(var account in bank.Accounts.Where(account => account.AccountId == id))
                {
                    user = account;
                }
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return user;
        }
        public string CreateBank(string name, string address, string currencyCode)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Bank name is not valid!");
           if(BankList.Banks.Count!=0 & BankList.Banks.Any(a=>a.name==name))
            {
                throw new Exception("Bank Already Exist!");
            }
           if(!Currency.curr.ContainsKey(currencyCode))
            {
                throw new Exception("Invalid Currency Code");
            }
            Bank bank = new Bank(name , currencyCode);
            BankList.Banks.Add(bank);
            return bank.BankId;
        }
        public string CreateAccount(string bankId, string name, string password, int choice)
        {

            string Id;
            bank = FindBank(bankId);

            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is not valid!");
            if (bank.Accounts.Count != 0 & bank.Accounts.Any(p => p.name == name) == true)
                throw new Exception("Account already exists!");
            if (BankList.Banks.Count != 0 & BankList.Banks.Any(p => p.BankId == bankId) != true)
                throw new Exception("Bank doesn't exists!");

            if (choice == 1)
            {
                Staff s = new Staff(name, password);
                bank.StaffAccount.Add(s);
                Id = s.StaffId;
            }
            else
            {
                Account a = new Account(name,  password);
                bank.Accounts.Add(a);
                Id = a.AccountId;
            }
            return Id;
        }
        public static Account FindAccount(Bank bank, string userId)
        {
            foreach (var account in bank.Accounts.Where(account => account.AccountId == userId))
            {
                return account;
            }
            return null;
        }
        public static Bank FindBank(string bankId)
        {
            foreach (var i in BankList.Banks.Where(i => i.BankId == bankId))
            {
                return i;
            }

            return null;
        }
        public void AddCurrency(string code, double rate)
        {
            Currency.curr[code] = rate;
        }
        public void UpdateCharges(double rtgs, double imps, int choice)
        {
            if (choice == 1)
            {
                bank.RTGSsameBank = rtgs;
                bank.IMPSsameBank = imps;
            }
            else if (choice == 2)
            {
                bank.RTGSdifferentBank = rtgs;
                bank.IMPSdifferentBank = imps;
          
            }
        }
        public Account ViewHistory(string Id)
        {
            Account user = null;
            try
            {
                foreach (var account in bank.Accounts.Where(account => account.AccountId == Id))
                {
                    user = account;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ViewHistory: {0}", ex.Message);

            }
            return user;
        }
        public Account UpdateChanges(string bankId, string userId)
        {
            Account user;
            try
            {
                bank = FindBank(bankId);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                user = FindAccount(bank, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public void DeleteAccount(string bankId, string userId)
        {
            Account user;
            try
            {
                bank = FindBank(bankId);
                if (bank == null)
                {
                    throw new Exception("Bank does not exist");
                }
                user = FindAccount(bank, userId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            bank.Accounts.Remove(user);
        }
    }
}
