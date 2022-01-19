using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.DbModels;
using ATM.Services.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Services
{
    public class DbServices : IDbServices
    {

        private readonly IMapper _mapper;
        private readonly BankContext _bankContext;
        public readonly ICustomerServices _accountService;

        public DbServices(BankContext bankContext, IMapper mapper)
        {
            _mapper = mapper;
            _bankContext = bankContext;
            _bankContext.Database.EnsureCreated();
        }
        public void revertTransaction(string txnId)
        {
            Transaction transaction = GetTransactionById(txnId);
            double amount = transaction.Amount;
            string fromAccId = transaction.SrcAccount;
            string toAccId = transaction.DepAccount;
        //    _accountService.transfer(amount , toAccId, fromAccId, amount);
        }
        public string CreateBank(string name, string address, string currencyCode)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Bank name is not valid!"); // use constants

            Bank bank = new Bank
            {
                BankName = name,
                Id = name.GenId(),
                Countrycode = currencyCode,
                ////check imps rtgs 

            };

            return bank.Id;
        }
        public Customer CreateCustomerAccount(string bankId, string name, string password, int choice)
        {
            //   Bank bank =  GetBankById(bankId);

            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is not valid!");
            if (_bankContext.Account.Any(p => p.Name == name))                     // check
                throw new Exception("Account already exists!");

            Customer a = new Customer
            {
                Name = name,
                Password = password,
                CustomerId = name.GenId(),
                BankId = bankId,

            };
            return a;
        }
        public Employee CreateStaffAccount(string bankId, string name, string password)
        {
            //   bank = GetBankById(bankId);
            if (string.IsNullOrEmpty(name))
                throw new Exception("Name is not valid!");
            if (_bankContext.Account.Any(p => p.Name == name))                     // check
                throw new Exception("Account already exists!");
            Employee a = new Employee
            {
                Name = name,
                Password = password,
                EmployeeId = name.GenId(),
                BankId = bankId,
            };
            return a;
        }

        public void AddBank(Bank bank)
        {
            using (_bankContext)
            {
                DbBankModel bank_ = _mapper.Map<DbBankModel>(bank);
                _bankContext.Bank.Add(bank_);
                _bankContext.SaveChanges();
            }
        }
        public void AddStaff(Employee staff)
        {
            using (_bankContext)
            {
                DbEmployeeModel staff_ = _mapper.Map<DbEmployeeModel>(staff);
                _bankContext.Staff.Add(staff_);
                _bankContext.SaveChanges();
            }
        }
        public void AddAccount(Customer account)
        {
            using (_bankContext)
            {
                DbCustomerModel acc_ = _mapper.Map<DbCustomerModel>(account);
                _bankContext.Account.Add(acc_);
                _bankContext.SaveChanges();
            }
        }
        public void AddCurrency(Currency currency)
        {
            using (_bankContext)
            {
                DbCurrencyModel currency_ = _mapper.Map<DbCurrencyModel>(currency);
                _bankContext.Currency.Add(currency_);
                _bankContext.SaveChanges();
            }
        }
        public void AddTransaction(Transaction transaction)
        {
            using (_bankContext)
            {
                DbTransactionModel transaction_ = _mapper.Map<DbTransactionModel>(transaction);
                _bankContext.Transaction.Add(transaction_);
                _bankContext.SaveChanges();
            }
        }

        public void UpdateCharges(double rtgs, double imps, int choice , string bankId)
        {
         //   DbBankModel bank = _bankContext.Bank.FirstOrDefault(b => b.Id == bankId);
            if (choice == 1)
            {
                DbBankModel bank = _bankContext.Bank.FirstOrDefault(b => b.Id == bankId);
                bank.RTGSsameBank = rtgs;
                bank.IMPSsameBank = imps;
            }
            else if (choice == 2)
            {
                DbBankModel bank = _bankContext.Bank.FirstOrDefault(b => b.Id == bankId);
                bank.RTGSdifferentBank = rtgs;
                bank.IMPSdifferentBank = imps;
            }
            _bankContext.SaveChanges();
        }
        public Transaction GetTransactionById(string txnId)
        {
            using (_bankContext)
            {

                DbTransactionModel transaction ;
                transaction = _bankContext.Transaction.FirstOrDefault(t => t.TransactionId == txnId);
                if (transaction == null)
                {
                    throw new TransactionNotFoundException();
                }
                return _mapper.Map<Transaction>(transaction);
            }
        }

        public IList<Transaction> GetTransactions(string accountId)
        {
            IList<DbTransactionModel> transactions;
            using (_bankContext)
            {
                // Use mapping here to convert from DBmodel to general model
                transactions = _bankContext.Transaction.Where(t => t.SrcAccount == accountId).ToList();
            }
            if (transactions.Count == 0 || transactions == null)
            {
                throw new NoTransactionsException();
            }
            return _mapper.Map<IList<Transaction>>(transactions);      // check
        }
        public Customer ViewHistory(string Id)
        {
            DbCustomerModel user = null;
            try
            {
                foreach (var account in _bankContext.Account.Where(account => account.CustomerId == Id))
                {
                    user = account;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ViewHistory: {0}", ex.Message);

            }
            return _mapper.Map<Customer>(user);
        }
        //check existence
        public void CheckBankExistance(string bankId)
        {
            using (_bankContext)
            {
                if (!_bankContext.Bank.Any(b => b.Id == bankId))
                {
                    throw new BankDoesnotExistException();
                }
            }
        }

        public void CheckCurrencyExistance(string bankId, string currencyName)
        {
            using (_bankContext)
            {
                if (!_bankContext.Currency.Any(c => c.BankId == bankId && c.Code == currencyName))
                {
                    throw new CurrencyDoesNotExistException();
                }
            }
        }

        public void CheckStaff(string bankId, string staffId)
        {
            using (_bankContext)
            {
                if (!_bankContext.Staff.Any(e => e.BankId == bankId && e.EmployeeId == staffId))
                {
                    throw new StaffDoesNotExistException();
                }
            }
        }

        public Customer CheckAccountExistance(string bankId, string accountId)
        {
            DbCustomerModel user;
            {
                using (_bankContext)
                {
                    if (!_bankContext.Account.Any(a => a.BankId == bankId && a.CustomerId == accountId))
                    {
                        throw new AccountDoesNotExistException();
                        //  user = bankContext.Account.Any(a => a.BankId == bankId && a.Id == accountId);

                    }
                    else
                    {
                        user = _bankContext.Account.FirstOrDefault(a => a.BankId == bankId && a.CustomerId == accountId);
                    }
                }
                return _mapper.Map<Customer>(user);
            }
        }

            // get Id

            public Dictionary<string, string> GetAllBankNames()
            {
                Dictionary<string, string> bankNames = new Dictionary<string, string>();
                using (_bankContext)
                {
                    var banks = _bankContext.Bank.Where(b => b.Id != "");
                    foreach (var bank in banks)
                    {
                        bankNames.Add(bank.Id, bank.BankName);
                    }
                }
                return bankNames;
            }

            public string GetAccountIdByname(string bankId, string username)
            {
                string id;
                using (_bankContext)
                {
                    DbCustomerModel account = _bankContext.Account.FirstOrDefault(a => a.CustomerId == bankId && a.Name == username);
                    if (account == null)
                    {
                        throw new AccountDoesNotExistException();
                    }
                    id = account.CustomerId;
                }
                return id;
            }

            public string GetStaffIdByname(string bankId, string username)
            {
            
            DbEmployeeModel staff_;
                string id;
                using (_bankContext)
                {
                     staff_ = _bankContext.Staff.FirstOrDefault(e => e.BankId == bankId && e.Name == username);
                    if (staff_ == null)
                    {
                        throw new EmployeeDoesNotExistException();
                    }
                    id = staff_.EmployeeId;
                }
                return id;
            }
        // get bank , employee
        public Bank GetBankById(string bankId)
        {

            CheckBankExistance(bankId);
            using (_bankContext)
            {
                DbBankModel bank_ = _bankContext.Bank.FirstOrDefault(b => b.Id == bankId);

                return _mapper.Map<Bank>(bank_);
            }
        }

            public Employee GetEmployeeById(string bankId, string employeeId)
            {
                CheckStaff(bankId, employeeId);
                using (_bankContext)
                {
                    DbEmployeeModel employee_= _bankContext.Staff.FirstOrDefault(e => e.BankId == bankId && e.EmployeeId == employeeId);
                return _mapper.Map<Employee>(employee_);    
            }
            }

            public Customer GetAccountById(string bankId, string accountId)
            {
                CheckAccountExistance(bankId, accountId);
                using (_bankContext)
                {
                    DbCustomerModel customer_= _bankContext.Account.FirstOrDefault(a => a.BankId == bankId && a.CustomerId == accountId);
                return _mapper.Map<Customer>(customer_);
            }
            }

            public Currency GetCurrencyByName(string bankId, string currencyName)
            {

                CheckCurrencyExistance(bankId, currencyName);
                using (_bankContext)
                {
                    DbCurrencyModel curr_= _bankContext.Currency.FirstOrDefault(c => c.BankId == bankId && c.Code == currencyName);
                return _mapper.Map<Currency>(curr_);
            }

            }

            public void UpdateBank(Bank bank)
            {
                using (_bankContext)
                {
                    DbBankModel currentBank = _bankContext.Bank.First(b => b.Id == bank.Id);
                    currentBank.BankName = bank.BankName;
                    currentBank.IMPSsameBank = bank.IMPSsameBank;
                    currentBank.IMPSdifferentBank = bank.IMPSdifferentBank;
                    currentBank.RTGSdifferentBank = bank.RTGSdifferentBank;
                    currentBank.RTGSsameBank = bank.RTGSsameBank;
                    _bankContext.SaveChanges();
                }
            }
            public void UpdateEmployee(Employee employee)
            {

                using (_bankContext)
                {
                    DbEmployeeModel currentEmployee = _bankContext.Staff.First(e => e.BankId == employee.BankId && e.EmployeeId == employee.EmployeeId);
                    currentEmployee.Name = employee.Name;
                    currentEmployee.Password = employee.Password;
                    _bankContext.SaveChanges();
                }
            }

            public void UpdateAccount(Customer account)
            {
                using (_bankContext)
                {
                    DbCustomerModel currentAccount = _bankContext.Account.First(a => a.BankId == account.BankId && a.CustomerId == account.CustomerId);
                    currentAccount.Name = account.Name;
                    currentAccount.Password = account.Password;
                    currentAccount.CurrentBalance = account.CurrentBalance;
                    _bankContext.SaveChanges();
                }
            }

            public void UpdateCurrency(Currency currency , string bankId)
            {
                using (_bankContext)
                {
                    DbCurrencyModel currentCurrency = _bankContext.Currency.First(c => c.BankId == bankId && c.Code == currency.Code);
                    currentCurrency.ExchangeRate = currency.ExchangeRate;
                    _bankContext.SaveChanges();
                }
            }


            ///
            public void DeleteBank(string bankId)
            {
                using ( _bankContext )
                {
                    DbBankModel bank = _bankContext.Bank.First(b => b.Id == bankId);

                    var staff = _bankContext.Staff.Where(e => e.BankId == bankId).ToList();

                    var accounts = _bankContext.Account.Where(a => a.BankId == bankId).ToList();

                    _bankContext.Currency.RemoveRange(_bankContext.Currency.Where(c => c.BankId == bankId));
                    _bankContext.SaveChanges();
                }
            }

            public void DeleteAccount(string bankId, string accountId)
            {
                using (_bankContext )
                {
                    DbCustomerModel account = _bankContext.Account.First(a => a.CustomerId == accountId && a.BankId == bankId);
                    _bankContext.SaveChanges();
                }
            }


        }
    }

