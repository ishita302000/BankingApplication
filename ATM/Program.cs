using System;
using System.Collections.Generic;
using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services;

namespace ATM.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "";
            string password = "";
            int id ;
            // Console.WriteLine("Hello World!");
            BankManager bankmanager = new BankManager("state", 123);
            Console.WriteLine("Press 1 for create Account");
            Console.WriteLine("Press 2 for Log in");
                int x1 = Convert.ToInt32(Console.ReadLine());
            if (x1 ==1 )
            {
                //create
                username = InputTakenFromUser.GetString("Please enter username");
                password = InputTakenFromUser.GetString("Please enter password");
                id = InputTakenFromUser.getmsg();
                bankmanager.addaccount(username, password , id);
            }
            do
            {
                username= InputTakenFromUser.GetString("Please enter username");
            } while (!bankmanager.checkusername(username));

            do
            {
                password = InputTakenFromUser.GetString("Please enter password");
                id = InputTakenFromUser.getmsg();

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
                  int   deposit = InputTakenFromUser.getMessage();
                    double currentBalance = bankmanager.deposit(deposit, id);
                    Console.WriteLine("Successfully deposited : " + deposit);
                    Console.WriteLine("Current balance : " + currentBalance);
                    bankmanager.addtransaction (username, $"{deposit} deposited" , id);
                }
                else if ( input == 2)
                {
                    int withdraw = InputTakenFromUser.getMessage();
                    double currentBalance = bankmanager.withdraw(withdraw, id);
                    Console.WriteLine("Successfully withdrawn : " + withdraw);
                    Console.WriteLine("Current Balance : " + currentBalance);
               //     Console.WriteLine("Successfully withdrawn ");
                    bankmanager.addtransaction( username, $"{withdraw} withdrawn" , id);
                }
                else if (input == 3)
                {     
                    int accNo1 = InputTakenFromUser.getmsg();
                    int accNo2 = InputTakenFromUser.getmsg();
                    int amount = InputTakenFromUser.getMessage();
                    try
                    {
                        double currentBalance = bankmanager.transfer(amount, accNo1, accNo2);
                        bankmanager.addtransaction(username, $"{amount} has been transferred to account {accNo2}", accNo2);
                        Console.WriteLine("Current Balance : " + currentBalance);
                    }
                    catch (UserNotFoundException)
                    {
                        Console.WriteLine("User not found.");
                    }
                }
               else if ( input == 4)
                {
                    bankmanager.transactionHistory(username , id);
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
