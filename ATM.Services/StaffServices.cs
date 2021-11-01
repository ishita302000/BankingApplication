using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ATM.Models;
using ATM.Models.Enums;

namespace ATM.Services
{
   public class StaffServices : BankManager
    {
      public  Staff staff;
        StaffServices(string name , string id , StaffLoginType access= StaffLoginType.StaffMember) :base(name,id)
        {
            staff = new Staff(name,id,access);
        }
        public bool findAccount(string AccId , BankManager BankServices)
        {
            foreach( var x in StaffServices.AxisBank.Accounts)
            {
                Account acc = x.value;
                if( acc.AccountId == AccId)
                {
                    return true;
                }
            }
            return false;
        }
        public bool updateStatus(string AccId , AccountStatus status , BankManager bankservice)
        {
            Account account = null;
            foreach( var x in bankservice.AxisBank.Accounts)
            {
                account = x.value;
                if (account.AccountId == AccId)
                    break;
            }
            if( account!=null)
            {
                account.status = status;
                return true;
            }
            return false;
        }
        public bool revertTransaction()
        {
            return false;
        }
        public bool currency()
        {
            return false;

        }
    }
}
