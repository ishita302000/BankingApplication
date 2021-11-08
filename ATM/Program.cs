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
            string accountId = "";
            string CurrentUserAccId = "";
            string BankId = "";
            string Bankname = "";
            string CountryCode = "";
            string BankAddress = "";
            // Console.WriteLine("Hello World!");
            ConsoleOutput.Welcome();
            BankManager bankmanager = new BankManager();
            StaffServices staffmanager = new StaffServices();
            Console.WriteLine(ConstantMessages.SetupFirstBank);
        //   BankId = bankmanager.bank.BankId;
        //      var bank = bankmanager.

        //    Console.WriteLine("Your Bank ID is"+ BankId);
        //   Console.WriteLine();
        SetUpBank:
            Bankname = InputTakenFromUser.BankName();
            BankAddress =InputTakenFromUser.Address();
            CountryCode = Console.ReadLine();
        
            try
            {
                BankId= staffmanager.CreateBank(Bankname, BankAddress, CountryCode);
                ConsoleOutput.BankSuccessfullCreation();
                ConsoleOutput.BankId(BankId);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto SetUpBank;
            }
          
            AccountServices AccountManager = new AccountServices(username , CountryCode);
        StaffSetUp:

            do
            {
                username= InputTakenFromUser.GetString("Please enter username");
            } while (!bankmanager.UserAccountExit(username));
            do
            {
                password = InputTakenFromUser.GetString("Please enter password");
             //   accountid = InputTakenFromUser.getmsg();
            } while (!bankmanager.userlogin(username, password ));
            do
            {
                accountId = InputTakenFromUser.getmsg();
            } while(!bankmanager.UsercheckId(accountId));
         
            ConsoleOutput.Login(username);
            ConsoleOutput.ChooseOption();
            Console.WriteLine();
            Choice input = (Choice)Convert.ToInt32(Console.ReadLine());
            while (input!= Choice.quit)
            {     
                if( input == Choice.deposit)
                { 
                    int depositInput = InputTakenFromUser.getMessage();
                  //  var currentId =  bankmanager.addaccount(username , password);
                    int depositamount = Convert.ToInt32(depositInput);
                double currentBalance = AccountManager.deposit( depositamount, CurrentUserAccId , CountryCode);
                   
                    Console.WriteLine("Current balance : " + currentBalance);
                    AccountManager.addtransaction(CurrentUserAccId , CurrentUserAccId , depositamount , TransactionType.Deposited , BankId , BankId);
                }
                else if (input == Choice.withdraw)
                {
                    double withdrawamount = InputTakenFromUser.getMessage();
                       //    double currentBalance = bankmanager.withdraw(withdraw, accountid);
                   double currentBalance = AccountManager.withdraw(withdrawamount,CurrentUserAccId);
                    //  bankmanager.withdraw(withdrawamount, accountid);
                    Console.WriteLine("Successfully withdrawn : " + withdrawamount);
                    Console.WriteLine("Current Balance : " + currentBalance);
                    //     Console.WriteLine("Successfully withdrawn ");
                    AccountManager.addtransaction(CurrentUserAccId , CurrentUserAccId ,withdrawamount, TransactionType.Withdraw);
                }
                else if (input == Choice.transfer)
                {
                    string SenderaccNo1 = InputTakenFromUser.getmsg();  // 
                    string RecieveraccNo2 = InputTakenFromUser.getmsg();
                    int amount = InputTakenFromUser.getMessage();
                    try
                    {
                        AccountManager.transfer(amount, SenderaccNo1, RecieveraccNo2);
                        AccountManager.addtransaction(SenderaccNo1,RecieveraccNo2,amount,TransactionType.Debited);
                     
                    }
                    catch (UserNotFoundException)
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else if (input == Choice.transactionHistory)
                {
                    ConsoleOutput.TransactionHistory(AccountManager.GettransactionHistory(username , CurrentUserAccId));

                }

                else
                {
                    Console.WriteLine("Enter valid option ");
                }

                ConsoleOutput.ChooseOption();
                input =  (Choice) Convert.ToInt32(Console.ReadLine());

            }
        }

    }
}
