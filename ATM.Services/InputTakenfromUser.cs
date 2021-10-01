using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services
{
   public  class InputTakenfromUser
    {
        public static string Accountno()
        {
            Console.WriteLine("Please Enter your Account number");
            string accountno = Console.ReadLine();
            return accountno;
        }
        public static string Username()
        {
            Console.WriteLine("Please Enter your username");
            string username = Console.ReadLine();
            return username;
        }
        public static string Password()
        {
            Console.WriteLine("Please Enter your Password");
            string password = Console.ReadLine();
            return password;
        }
        public static string Deposit()
        {
            Console.WriteLine("Please Enter the Amount to be Deposited");
            string deposit = Console.ReadLine();
            return deposit;
        }
        public static string Withdraw()
        {
            Console.WriteLine("Please Enter the Amount to be Withdrawn");
            string withdraw = Console.ReadLine();
            return withdraw;
        }
        public static string Transferamount()
        {
            Console.WriteLine("Please Enter to be Transfer");
            string transferamount = Console.ReadLine();
            return transferamount;
        }
        public static string  Input()
        {
            return Console.ReadLine();
             }

    }
}
