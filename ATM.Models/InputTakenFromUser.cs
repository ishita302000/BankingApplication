using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.CLI
{
    class InputTakenFromUser
    {
        private static string GetInput(string message)
        {
            Console.WriteLine("\n"+message+"\n");
            string result = Console.ReadLine();
            return result;
        }
        public static string Staff()
        {
            return GetInput(ConstantMessages.StaffName);
        }
        public  static string Username()
        {
            return GetInput(ConstantMessages.UserName);
        }
        public static string Password()
        {
            return GetInput(ConstantMessages.Password);
        }
        public static string DeleteUserName()
        {
            return GetInput(ConstantMessages.DeleteUserName);
        }
        public static string RecieverName()
        {
            return GetInput(ConstantMessages.RecieverName);
        }
        public static string DepositAmount()
        {
            return GetInput(ConstantMessages.DepositAmount);
        }
        public static string WithdrawAmount()
        {
            return GetInput(ConstantMessages.WithdrawAmount);
        }
        public static string Amount()
        {
            return GetInput(ConstantMessages.Amount);
        }
        public static string UpdateCurrency()
        {
            return GetInput(ConstantMessages.UpdateCurrency);
        }
        public static string InitializeAmount()
        {
            return GetInput(ConstantMessages.Amount);
        }
        public static string BankName()
        {
            return GetInput(ConstantMessages.BankName);
        }
        public static string branch()
        {
            return GetInput(ConstantMessages.BranchName);
        }
        

    }
}
