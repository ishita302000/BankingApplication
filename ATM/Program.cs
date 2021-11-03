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

            List<string> BankList = new List<string>();
            BankList.Add("Axis Bank");
            BankList.Add("HDFC Bank");
            BankList.Add("SBI Bank");
            BankList.Add("Kotak Bank");
           
            string username = "";
            string password = "";
            string accountId = "";
            string CurrentUserAccId = "";
            string BankId = "";
            string BankName = "";
            Outputs.ChooseBank();
            Outputs.BankName(BankList); // view

            BankName = InputTakenFromUser.bankname();
            // Console.WriteLine("Hello World!");
            BankManager bankmanager = new BankManager(BankName);
            BankId = bankmanager.bank.BankId;
            Console.WriteLine(" Your Bank ID is"+ BankId);

            Console.WriteLine("Press 1 for create Account");
            Console.WriteLine("Press 2 for Log in");
            Console.WriteLine();
            int x1 = Convert.ToInt32(Console.ReadLine());
            if (x1 ==1)
            {
                //create
                username = InputTakenFromUser.GetString("Please enter username");
                password = InputTakenFromUser.GetString("Please enter password");
             //   accountid = InputTakenFromUser.getmsg();
                 CurrentUserAccId =  bankmanager.addaccount(username, password); // accountid
                Outputs.AccountCreationSuccesful();
                Console.WriteLine($"{username} your Account ID is"+ CurrentUserAccId);
            }
            AccountServices AccountManager = new AccountServices(  username);

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
         
            Outputs.Login(username);
            Outputs.ChooseOption();
            Console.WriteLine();
            Choice input = (Choice)Convert.ToInt32(Console.ReadLine());
            while (input!= Choice.quit)
            {     
                if( input == Choice.deposit)
                { 
                    int depositInput = InputTakenFromUser.getMessage();
                  //  var currentId =  bankmanager.addaccount(username , password);
                    int depositamount = Convert.ToInt32(depositInput);
                double currentBalance = AccountManager.deposit( depositamount, CurrentUserAccId);
                   
                    Console.WriteLine("Current balance : " + currentBalance);
                    AccountManager.addtransaction(CurrentUserAccId , CurrentUserAccId , depositamount , TransactionType.Deposited);
                }
                else if (input == Choice.withdraw)
                {
                    int withdrawamount = InputTakenFromUser.getMessage();
                       //    double currentBalance = bankmanager.withdraw(withdraw, accountid);
                   int currentBalance = AccountManager.withdraw(withdrawamount,CurrentUserAccId);
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
                    Outputs.TransactionHistory(AccountManager.GettransactionHistory(username , CurrentUserAccId));

                }

                else
                {
                    Console.WriteLine("Enter valid option ");
                }

                Outputs.ChooseOption();
                input =  (Choice) Convert.ToInt32(Console.ReadLine());

            }
        }

    }
}
