using System;
using System.Collections.Generic;
using System.Text;
using ATM.Models;
namespace ATM.CLI
{
    class ConsoleOutput
    {
        public static void Welcome() // why static menthods??
        {
            Console.WriteLine(ConstantMessages.Welcome);
        }
        public static void Login()
        {
            Console.WriteLine(ConstantMessages.LoginOptions);
        }
        public static void WelcomeUser()
        {
            Console.WriteLine(ConstantMessages.WelcomeUser);
        }
        public static void WrongCredential()
        {
            Console.WriteLine(ConstantMessages.WrongCredential);
        }
        public static void AccountSuccessfullCreation()
        {
            Console.WriteLine(ConstantMessages.AccountSuccessfullCreation);
        }
        public static void BankSuccessfullCreation()
        {
            Console.WriteLine(ConstantMessages.BankSuccessfullCreation);
        }
        public static void CustomerChoice()
        {
            Console.WriteLine(ConstantMessages.CustomerChoice);
        }
        public static void StaffChoice()
        {
            Console.WriteLine(ConstantMessages.StaffChoice);
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
        public static void Balance()
        {
            Console.WriteLine(ConstantMessages.Balance);
        }
        public static void option()
        {
            Console.WriteLine(ConstantMessages.AccountCustomerChoice);
        }
        public static void InsufficientBalance()
        {
            Console.WriteLine(ConstantMessages.InsufficientBalance);
        }
        public static void InValidOption()
        {
            Console.WriteLine(ConstantMessages.InvalidOption);
        }
        public static void Exit()
        {
            Console.WriteLine(ConstantMessages.Exit);
        }
        public static void BankId(string bankId)
        {
            Console.WriteLine("\nYour Bank Id is: {0}. PLEASE NOTE IT!!!", bankId);
        }
        public static void AccountId(string accountId)
        {
            Console.WriteLine("\nYour Account Id is: {0}. PLEASE NOTE IT!!!", accountId);
        }
        public static void DepositSuccessfull(double amt)
        {
            Console.WriteLine("\n{0} deposited successfully", amt);
        }
        public static void WithdrawSuccessfull(double amt)
        {
            Console.WriteLine("\n{0} withdrawn successfully", amt);
        }
        public static void TransferSuccessfull(double amt)
        {
            Console.WriteLine("\n{0} transferred successfully", amt);
        }
        public static void TransactionHistory(Transaction userTransactionHistory)
        {
            Console.WriteLine("TRANSACTION HISTORY");
            Console.WriteLine("Transaction ID:" + userTransactionHistory.SrcAccount);
            Console.WriteLine(userTransactionHistory.Amount);
           // Console.WriteLine(userTransactionHistory.type + "to your account");
            if (userTransactionHistory.SrcAccount != userTransactionHistory.DepAccount)
            {
                Console.WriteLine("From " + userTransactionHistory.SrcAccount+ " to " + userTransactionHistory.DepAccount);
            }
            Console.WriteLine(userTransactionHistory.ToString());
         
        }
    }
}
