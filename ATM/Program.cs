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
            BankManager bankManager = new BankManager(new Bank("state", 123));
            Console.WriteLine("Press 1 for create Account");
            Console.WriteLine("Press 2 for Log in");
       //     bool createAccount = (Convert.ToInt32(InputTakenfromUser.Input()) == 1) ? true : false;
                int x1 = Convert.ToInt32(Console.ReadLine());
            if (x1 ==1 )
            {
                //create
                username = InputTakenfromUser.Username();
                password = InputTakenfromUser.Password();
                bankManager.addaccount(username, password);
           
            }
            do
            {
                 username= InputTakenfromUser.Username();
            } while (!bankManager.checkusername(username));

            do
            {
                password = InputTakenfromUser.Password();
            } while (!bankManager.checkpassword(username, password));

            //    StandardMessages.UserLoggedIn(userName);
            //    StandardMessages.ChooseAnOption();
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
                    string deposit = InputTakenfromUser.Deposit();
                    Console.WriteLine("Successfully deposited");
                      bankManager.addtransaction (username, $"{deposit} deposited");

                }
                else if ( input == 2)
                {
                    string withdraw = InputTakenfromUser.Withdraw();
                    Console.WriteLine("Successfully withdrawn ");
                    bankManager.addtransaction( username, $"{withdraw} withdrawn");

                }
                else if (input == 3)
                {

                    string accNo = InputTakenfromUser.Accountno();
                    string amount = InputTakenfromUser.Transferamount();
                    bankManager.addtransaction(username, $"{amount} has been transferred to {accNo}");

                }
                else if ( input == 4)
                {
                    List<string> userTransactionHistory = new List<string>(); 
                    Console.WriteLine("TRANSACTION HISTORY");
                    for (int i = 0; i < userTransactionHistory.Count; i++)
                    {
                        string transaction = userTransactionHistory[i];
                        Console.WriteLine();
                        Console.WriteLine(transaction);
                    }
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
