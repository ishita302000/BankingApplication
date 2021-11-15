using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models.Enums
{
   public enum  OperationsPerdormedByStaff
    {
        CreateAccount,
        UpdateAccountStatus,
        ChangeCurrency,
        Quit,
        Login,
        AccountCharges,
        TransactionHistory,
        LogOut,
        RevertTransaction,
        TransferMoney,
        DepositMoney
    }
}
