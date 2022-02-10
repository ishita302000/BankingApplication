using ATM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
    public interface IDbServices
    {
        void revertTransaction(string txnId);
       
        Bank CreateBank(string name, string address, string currencyCode);
        Customer CreateCustomerAccount(string bankId, string name, string password, int choice);
        Employee CreateStaffAccount(string bankId, string name, string password);
        void AddBank(Bank bank);
        void AddStaff(Employee staff);
        void AddAccount(Customer account);
        void AddCurrency(Currency currency);
        void AddTransaction(Transaction transaction);
        void UpdateCharges(double rtgs, double imps, int choice , string bankId);
        Transaction GetTransactionById(string txnId);
        IList<Transaction> GetTransactions(string accountId);
        Customer ViewHistory(string Id);
        void CheckBankExistance(string bankId);
        void CheckCurrencyExistance(string bankId, string currencyName);
        void CheckStaff(string bankId, string staffId);
        Customer CheckAccountExistance(string bankId, string accountId);
        IList<Bank> GetAllBankNames();
        string GetAccountIdByname(string bankId, string username);
        string GetStaffIdByname(string bankId, string username);
        Bank GetBankById(string bankId);
        Employee GetEmployeeById(string bankId, string employeeId);
        Customer GetAccountById(string bankId, string accountId);
        Currency GetCurrencyByName(string bankId, string currencyName);
        void UpdateBank(Bank bank);
        void UpdateEmployee(Employee employee);
        void UpdateAccount(Customer account);
        void UpdateCurrency(Currency currency , string bankId);
        void DeleteBank(string bankId);
        void DeleteAccount(string bankId, string accountId);


        //////////////
        ///
        
    }
}
