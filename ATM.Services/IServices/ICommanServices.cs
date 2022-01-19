using ATM.Models;
using ATM.Services.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.IServices
{
     public interface ICommanServices
    {
   
        Customer userlogin(string accid, string password, string bankid);
        Employee Stafflogin(string id, string password, string bankid);
        double viewbalance(Customer user);


    }
}
