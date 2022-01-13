using ATM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
     public interface ICommanServices
    {
        string addaccount(string username, string accountId, string password, double balance, string bankid);
        Customer userlogin(string accid, string password, string bankid);
        Employee Stafflogin(string id, string password, string bankid);
        bool StaffcheckId(string accountId);
        bool UsercheckId(string accountId);
        bool UserAccountExit(string username, string bankid);   // user
        IList<Transaction> GettransactionHistory(string username, string userid);
        bool StaffAccountExit(string username, string bankid);
        double viewbalance(Customer user);


    }
}
