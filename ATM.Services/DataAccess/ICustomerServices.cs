using ATM.Models;
using ATM.Services.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
    public interface ICustomerServices
    {
        void deposit(double amount, DbCustomerModel user, string currentycode, string bankid);
        bool withdraw(double amount, string accountId, DbCustomerModel user, string bankid);
        bool transfer(double amount, string accountId1, string accountId2, string SenderBankId, string RecieverBankId, string choice, string senderbankcurrencycode);
        double DeductCharge(double amount , double percent);
        DbCustomerModel GetAccount(string accId);
    }
}
