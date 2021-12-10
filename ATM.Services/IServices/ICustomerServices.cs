using ATM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
    public interface ICustomerServices
    {
        void deposit(double amount, Account user, string currentycode, string bankid);
        bool withdraw(double amount, string accountId, Account user, string bankid);
        bool transfer(double amount, string accountId1, string accountId2, string SenderBankId, string RecieverBankId, string choice, string senderbankcurrencycode);
        double DeductCharge(double amount , double percent);
        Account GetAccount(string accId);
    }
}
