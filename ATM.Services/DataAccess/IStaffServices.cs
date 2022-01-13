using ATM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
    public interface IStaffServices
    {
        bool revertTransaction();
        Customer checkAccount(string bankid, string id);
        string CreateBank(string name, string address, string currencyCode);
        string CreateAccount(string bankId, string name, string password, int choice);
        Customer FindAccount(Bank bank, string userId);
        Bank FindBank(string bankId);
        void AddCurrency(string code, double rate);
        void UpdateCharges(double rtgs, double imps, int choice);
        Customer ViewHistory(string Id);
        Customer UpdateChanges(string bankId, string userId);
        void DeleteAccount(string bankId, string userId);


    }
}
