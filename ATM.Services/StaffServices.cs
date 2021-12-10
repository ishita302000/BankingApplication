using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ATM.Models;
using ATM.Models.Enums;
using ATM.Models.Exceptions;

namespace ATM.Services
{
   public class StaffServices 
    {
       public   Bank bank;
      public  Staff staff;
        readonly BankContext bankContext = new BankContext();
    

        public StaffServices()
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Database.EnsureCreated();
            }
        }
        public bool revertTransaction()
        {
            return false;
        }
   /*     public double viewbalance(Account user)
        {
            return user.currentbalance;
        }
   */
     /*   public Account checkAccount(string bankid, string id)
        {
            Account user = null;
            try
            {
                bank = FindBank(bankid);
                if(bank==null)
                {
                    throw new Exception("Bank doesn't exist! ");
                }
                // replace with isExist in all places
                foreach(var account in bank.Accounts.Where(account => account.Id == id))
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
     */
        public string CreateBank(string name, string address, string currencyCode)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Bank name is not valid!"); // use constants
           if(BankList.Banks.Count!=0 & BankList.Banks.Any(a=>a.Name==name))
            {
                throw new Exception("Bank Already Exist!");
            }
         /*  if(!Currency.Curriences.ContainsKey(currencyCode))
            {
                throw new Exception("Invalid Currency Code");
            }
           */
            Bank bank = new Bank();
            BankList.Banks.Add(bank);
            return bank.Id;
        }
        public string CreateAccount(string bankId, string name, string password, int choice)
        {

            string Id;
            bank = FindBank(bankId);

            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is not valid!");
            if (  bankContext.Account.Any(p => p.Name == name) == true )                     // check
                throw new Exception("Account already exists!");
            if (BankList.Banks.Count != 0 & BankList.Banks.Any(p => p.Id == bankId) != true)
                throw new Exception("Bank doesn't exists!");

            if (choice == 1)
            {
                Staff s = new Staff();

                bankContext.Staff.Add(s);
                return s.Id;
            }
            else
            {
                Account a = new Account();
                bankContext.Account.Add(a);
                Id = a.Id;
            }
            return Id;
        }
  /*      public static Account FindAccount(Bank bank, string userId)
        {
            foreach (var account in bankContext.Account.Where(account => account.Id == userId))
            {
                return account;
            }
            return null;
        }*/
        public static Bank FindBank(string bankId)
        {
            foreach (var i in BankList.Banks.Where(i => i.Id == bankId))
            {
                return i;
            }

            return null;
        }
        //Add bank currency transaction
        public void AddBank(Bank bank)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Bank.Add(bank);
                bankContext.SaveChanges();
            }
        }
        public void AddStaff(Staff staff)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Staff.Add(staff);
                bankContext.SaveChanges();
            }
        }
        public void AddAccount(Account account)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Account.Add(account);
                bankContext.SaveChanges();
            }
        }
        public void AddCurrency(Currency currency)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Currency.Add(currency);
                bankContext.SaveChanges();
            }
        }
        public void AddTransaction(Transaction transaction)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Transaction.Add(transaction);
                bankContext.SaveChanges();
            }
        }
   /*     public void AddCurrency(string code, double rate)
        {
            Currency currency = new Currency();
            currency.code = code;
            currency.exchangerate = rate;
            bankContext.Currency.Add(currency);
            //Currency.curr[code] = rate;
        }*/
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

        //jgg
        public Transaction GetTransactionById(string txnId)
        {
            using (BankContext bankContext = new BankContext())
            {
                Transaction transaction = bankContext.Transaction.FirstOrDefault(t => t.TransactionId == txnId);
                if (transaction == null)
                {
                    throw new TransactionNotFoundException();
                }
                return transaction;
            }
        }

        public IList<Transaction> GetTransactions(string accountId)
        {
            IList<Transaction> transactions;
            using (BankContext bankContext = new BankContext())
            {
                transactions = bankContext.Transaction.Where(t => t.RecieverAccountId == accountId || t.Account.Id == accountId).ToList();
            }
            if (transactions.Count == 0 || transactions == null)
            {
                throw new NoTransactionsException();
            }
            return transactions;
        }
        public Account ViewHistory(string Id)
        {
            Account user = null;
            try
            {
                foreach (var account in bankContext.Account.Where(account => account.Id == Id))
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
        //check existence
        public void CheckBankExistance(string bankId)
        {
            using (BankContext bankContext = new BankContext())
            {
                if (!bankContext.Bank.Any(b => b.Id == bankId))
                {
                    throw new BankDoesnotExistException();
                }
            }
        }

        public void CheckCurrencyExistance(string bankId, string currencyName)
        {
            using (BankContext bankContext = new BankContext())
            {
                if (!bankContext.Currency.Any(c => c.BankId == bankId && c.code == currencyName))
                {
                    throw new CurrencyDoesNotExistException();
                }
            }
        }

        public void CheckStaff(string bankId, string staffId)
        {
            using (BankContext bankContext = new BankContext())
            {
                if (!bankContext.Staff.Any(e => e.BankId == bankId && e.Id == staffId))
                {
                    throw new StaffDoesNotExistException();
                }
            }
        }

        public void CheckAccountExistance(string bankId, string accountId)
        {
            using (BankContext bankContext = new BankContext())
            {
                if (!bankContext.Account.Any(a => a.BankId == bankId && a.Id == accountId))
                {
                    throw new AccountDoesNotExistException();
                }
            }
        }

        // get Id

        public Dictionary<string, string> GetAllBankNames()
        {
            Dictionary<string, string> bankNames = new Dictionary<string, string>();
            using (BankContext bankContext = new BankContext())
            {
                var banks = bankContext.Bank.Where(b => b.Id != "");
                foreach (var bank in banks)
                {
                    bankNames.Add(bank.Id, bank.Name);
                }
            }
            return bankNames;
        }

        public string GetAccountIdByname(string bankId, string username)
        {
            string id;
            using (BankContext bankContext = new BankContext())
            {
                Account account = bankContext.Account.FirstOrDefault(a => a.BankId == bankId && a.Name == username);
                if (account == null)
                {
                    throw new AccountDoesNotExistException();
                }
                id = account.Id;
            }
            return id;
        }

        public string GetStaffIdByname(string bankId, string username)
        {
            string id;
            using (BankContext bankContext = new BankContext())
            {
                Staff staff = bankContext.Staff.FirstOrDefault(e => e.BankId == bankId && e.Name == username);
                if (staff == null)
                {
                    throw new EmployeeDoesNotExistException();
                }
                id = staff.Id;
            }
            return id;
        }
        // get bank , employee
        public Bank GetBankById(string bankId)
        {
            CheckBankExistance(bankId);
            using (BankContext bankContext = new BankContext())
            {
                return bankContext.Bank.FirstOrDefault(b => b.Id == bankId);
            }
        }

        public Staff GetEmployeeById(string bankId, string employeeId)
        {
            CheckStaff(bankId, employeeId);
            using (BankContext bankContext = new BankContext())
            {
                return bankContext.Staff.FirstOrDefault(e => e.BankId == bankId && e.Id == employeeId);
            }
        }

        public Account GetAccountById(string bankId, string accountId)
        {
            CheckAccountExistance(bankId, accountId);
            using (BankContext bankContext = new BankContext())
            {
                return bankContext.Account.FirstOrDefault(a => a.BankId == bankId && a.Id == accountId);
            }
        }

        public Currency GetCurrencyByName(string bankId, string currencyName)
        {
            CheckCurrencyExistance(bankId, currencyName);
            using (BankContext bankContext = new BankContext())
            {
                return bankContext.Currency.FirstOrDefault(c => c.BankId == bankId && c.code == currencyName);
            }
        }
        /*    public Account UpdateChanges(string bankId, string userId)
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
             }*/
     
        /////////
        public void UpdateBank(Bank bank)
        {
            using (BankContext bankContext = new BankContext())
            {
                Bank currentBank = bankContext.Bank.First(b => b.Id == bank.Id);
                currentBank.Name = bank.Name;
                currentBank.IMPSsameBank = bank.IMPSsameBank;
                currentBank.IMPSdifferentBank = bank.IMPSdifferentBank;
                currentBank.RTGSdifferentBank = bank.RTGSdifferentBank;
                currentBank.RTGSsameBank = bank.RTGSsameBank;
                bankContext.SaveChanges();
            }
        }

        public void UpdateEmployee(Staff employee)
        {
            using (BankContext bankContext = new BankContext())
            {
                Staff currentEmployee = bankContext.Staff.First(e => e.BankId == employee.BankId && e.Id == employee.Id);
                currentEmployee.Name = employee.Name;
                currentEmployee.Password = employee.Password;
                bankContext.SaveChanges();
            }
        }

        public void UpdateAccount(Account account)
        {
            using (BankContext bankContext = new BankContext())
            {
                Account currentAccount = bankContext.Account.First(a => a.BankId == account.BankId && a.Id == account.Id);
                currentAccount.Name = account.Name;
                currentAccount.Password = account.Password;
                currentAccount.currentbalance = account.currentbalance;
                bankContext.SaveChanges();
            }
        }

        public void UpdateCurrency(Currency currency)
        {
            using (BankContext bankContext = new BankContext())
            {
                Currency currentCurrency = bankContext.Currency.First(c => c.BankId == currency.BankId && c.code == currency.code);
                currentCurrency.exchangerate = currency.exchangerate;
                bankContext.SaveChanges();
            }
        }


        ///
        public void DeleteBank(string bankId)
        {
            using (BankContext bankContext = new BankContext())
            {
                Bank bank = bankContext.Bank.First(b => b.Id == bankId);

                var staff = bankContext.Staff.Where(e => e.BankId == bankId).ToList();

                var accounts = bankContext.Account.Where(a => a.BankId == bankId).ToList();

                bankContext.Currency.RemoveRange(bankContext.Currency.Where(c => c.BankId == bankId));
                bankContext.SaveChanges();
            }
        }

        public void DeleteAccount(string bankId, string accountId)
        {
            using (BankContext bankContext = new BankContext())
            {
                Account account = bankContext.Account.First(a => a.Id == accountId && a.BankId == bankId);

                bankContext.SaveChanges();
            }
        }

        public void DeleteStaffAccount(string bankId, string employeeId)
        {
            using (BankContext bankContext = new BankContext())
            {
                Staff employee = bankContext.Staff.First(e => e.Id == employeeId && e.BankId == bankId);

                bankContext.SaveChanges();
            }
        }

        public void DeleteCurrency(string bankId, string currencyName)
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Remove(bankContext.Currency.First(c => c.BankId == bankId && c.code == currencyName));
                bankContext.SaveChanges();
            }
        }
    }
}
