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
        public static double Deposit()
        {
            Console.WriteLine("Please Enter the Amount to be Deposited");
            double deposit = Convert.ToDouble(Console.ReadLine());
            return deposit;
        }
        public static double Withdraw()
        {
            Console.WriteLine("Please Enter the Amount to be Withdrawn");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            return withdraw;
        }
        public static double Transferamount()
        {
            Console.WriteLine("Please Enter to be Transfer");
            double transferamount = Convert.ToDouble(Console.ReadLine());
            return transferamount;
        }
        public static string  Input()
        {
            return Console.ReadLine();
             }

    }
}
