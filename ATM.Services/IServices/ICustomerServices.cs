using ATM.Models;
using ATM.Services.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
    public interface ICustomerServices
    {
        void Deposit(double amount, Customer user, string currentycode);
        bool Withdraw(double amount,  Customer user);
        bool transfer(double amount, string accountId1, string accountId2, string SenderBankId, string RecieverBankId, string choice, string senderbankcurrencycode);
        double DeductCharge(double amount , double percent);
       
    }
}
