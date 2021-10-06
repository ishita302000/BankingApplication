using System;
using System.Collections.Generic;
using ATM.Models;
using ATM.Services;

namespace ATM.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "";
            string password = "";
            // Console.WriteLine("Hello World!");
            BankManager bankmanager = new BankManager(new Bank("state", 123));
            Console.WriteLine("Press 1 for create Account");
            Console.WriteLine("Press 2 for Log in");
                int x1 = Convert.ToInt32(Console.ReadLine());
            if (x1 ==1 )
            {
                //create
                username = Input.getmessage();
                password = Input.getmessage();
                bankmanager.addaccount(username, password);
           
            }
            do
            {
                username= Input.getmessage();
            } while (!bankmanager.checkusername(username));

            do
            {
                password = Input.getmessage();
            } while (!bankmanager.checkpassword(username, password));

            Console.WriteLine("Successfully Login ");
            Console.WriteLine();
            Console.WriteLine("Press 0 to log out");
            Console.WriteLine("Press 1 to deposit money");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money");
            Console.WriteLine("Press 4 to show transaction history");
            Console.WriteLine();
            int input = Convert.ToInt32(Console.ReadLine());
            while ( input!= 0)
            {
                if ( input == 1)
                {
                    //    double deposit = InputTakenfromUser.Deposit();
                    double deposit = Input.getMessage();
                    double currentBalance = bankmanager.deposit(deposit, username);
                    Console.WriteLine("Successfully deposited : " + deposit);
                    Console.WriteLine("Current balance : " + currentBalance);
                    bankmanager.addtransaction (username, $"{deposit} deposited");
                }
                else if ( input == 2)
                {
                    double withdraw = Input.getMessage();
                    double currentBalance = bankmanager.withdraw(withdraw, username);
                    Console.WriteLine("Successfully withdrawn : " + withdraw);
                    Console.WriteLine("Current Balance : " + currentBalance);
               //     Console.WriteLine("Successfully withdrawn ");
                    bankmanager.addtransaction( username, $"{withdraw} withdrawn");
                }
                else if (input == 3)
                {     
                    string accNo = Input.getmessage();
                    double amount = Input.getMessage();
                    double currentBalance = bankmanager.transfer(amount, accNo , username);
                    bankmanager.addtransaction(username, $"{amount} has been transferred to account {accNo}");
                    Console.WriteLine("Current Balance : " + currentBalance);
                }
               else if ( input == 4)
                {
                    bankmanager.transactionHistory(username);
                } 
                else
                {
                    Console.WriteLine("Enter valid option ");
                }
                Console.WriteLine("Press 0 to log out");
                Console.WriteLine("Press 1 to deposit money");
                Console.WriteLine("Press 2 to withdraw money");
                Console.WriteLine("Press 3 to transfer money");
                Console.WriteLine("Press 4 to show transaction history");
              
                input = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
