using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.CLI
{
    class Outputs
    {
      
        public static void AccountCreationSuccesful()
        {
            Console.WriteLine("Account Created Successfully");
        }

        public static void Login(string userName) 
        { 
            Console.WriteLine($"{userName} is logged in");  
        }

        public static void ChooseOption()
        {
            Console.WriteLine();
            Console.WriteLine("Press 0 to log out");
            Console.WriteLine("Press 1 to deposit money");
            Console.WriteLine("Press 2 to withdraw money");
            Console.WriteLine("Press 3 to transfer money");
            Console.WriteLine("Press 4 to show transaction history");
            Console.WriteLine();
        }
        public static void Deposit(double amount)
        {
       //     Console.WriteLine();
            Console.WriteLine( amount + " deposited successfully");
        }
        public static void Withdraw(double amount)
        {
           // Console.WriteLine();
            Console.WriteLine( amount + " withdrawn successfully");
        }
        public static void Transfer(double amount, string accNo)
        {
            Console.WriteLine();
            Console.WriteLine($"{amount} has been succesfully transfered to {accNo}");
        }
        public static void TransactionHistory(List<string> userTransactionHistory)
        {
            Console.WriteLine("TRANSACTION HISTORY");
            foreach (string transaction in userTransactionHistory)
            {
                Console.WriteLine();
                Console.WriteLine(transaction);
            }
        }
        public static void validOption()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a valid option");
        }

        public static void invalid()
        {
            Console.WriteLine("Please enter a valid number");
        }
        public static void AccountId(string username , string accountId)
        {
          //  Console.WriteLine($"{username} your account Id is " + AccountId);
        }

    }
}
