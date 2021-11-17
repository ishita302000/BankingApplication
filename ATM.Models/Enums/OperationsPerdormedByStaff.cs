using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models.Enums
{
   public enum  OperationsPerdormedByStaff
    {
        CreateAccount = 1,
        UpdateAccountStatus,
        ChangeCurrency,
        UpdateServiceCharge,
        TransactionHistory,
        RevertTransaction,
        LoginAnotherAccount,
        LogOut
    }
}
