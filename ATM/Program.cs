﻿using System;
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

            Outputs.ChooseBank();
            Outputs.BankName();

            // Console.WriteLine("Hello World!");
            BankManager bankmanager = new BankManager("state", 123);
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
                var CurrentUserAccId =  bankmanager.addaccount(username, password);
                Outputs.AccountCreationSuccesful();
                Console.WriteLine($"{username} your Account ID is"+ CurrentUserAccId);
            }
            /*    if(x1==2)
                {

                }*/
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
            } while(!bankmanager.UsercheckId(a));
         
            Outputs.Login(username);
            Outputs.ChooseOption();
            Console.WriteLine();
            Choice input = (Choice)Convert.ToInt32(Console.ReadLine());
            while (input!= Choice.quit)
            {     
                if( input == Choice.deposit)
                { 
                    int depositInput = InputTakenFromUser.getMessage();
                    var currentId =  bankmanager.addaccount(username , password);
                    int depositamount = Convert.ToInt32(depositInput);
                double currentBalance = AccountServices.deposit( depositamount, currentId);
                   
                    Console.WriteLine("Current balance : " + currentBalance);
                    bankmanager.addtransaction(username, $"{depositamount} deposited");
                }
                else if (input == Choice.withdraw)
                {
                    int withdrawamount = InputTakenFromUser.getMessage();
                    var currentId = bankmanager.addaccount(username, );
                //    double currentBalance = bankmanager.withdraw(withdraw, accountid);
                   int currentBalance = AccountServices.withdraw(withdrawamount, currentId);
                     //  bankmanager.withdraw(withdrawamount, accountid);
                    Console.WriteLine("Successfully withdrawn : " + withdrawamount);
                    Console.WriteLine("Current Balance : " + currentBalance);
                    //     Console.WriteLine("Successfully withdrawn ");
                    bankmanager.addtransaction(username, $"{withdrawamount} withdrawn");
                }
                else if (input == Choice.transfer)
                {
                    string accNo1 = InputTakenFromUser.getmsg();
                    string accNo2 = InputTakenFromUser.getmsg();
                    int amount = InputTakenFromUser.getMessage();
                    try
                    {
                        bankmanager.transfer(amount, accNo1, accNo2);
                        bankmanager.addtransaction(username, $"{amount} has been transferred to account {accNo2}");
                     
                    }
                    catch (UserNotFoundException)
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else if (input == Choice.transactionHistory)
                {
                    Outputs.TransactionHistory(bankmanager.GettransactionHistory(username , accountid));

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
