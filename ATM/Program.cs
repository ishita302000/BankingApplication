using System;
using System.Collections.Generic;
using ATM.Models;
using ATM.Models.Enums;
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
            string StaffName = "";
            string Staffpass = "";
            int choice1 = 0;
            Account reciever;
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto SetUpBank;
            }

            AccountServices AccountManager = new AccountServices(username, CountryCode);
        StaffSetUp:
            Console.WriteLine(ConstantMessages.StaffName);
            StaffName = InputTakenFromUser.Input();
            Staffpass = InputTakenFromUser.Password();
            string StaffAccountId;
            try
            {
                StaffAccountId= staffmanager.CreateAccount(BankId, StaffName, Staffpass, 1);
                ConsoleOutput.AccountId(StaffAccountId);
                ConsoleOutput.AccountSuccessfullCreation();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                goto StaffSetUp;
            }
        LoginPage:
            ConsoleOutput.Login();   // banksetup staffsetup coustomerlogin
            LoginType loginOptions;
            try
            {
                loginOptions = (LoginType)(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto LoginPage;
            }
            Console.Clear();
            if (loginOptions == LoginType.BankSetup)
            {
                goto SetUpBank;
            }
            else if (loginOptions == LoginType.Stafflogin)
            {
                Staff bankstaff;
                Console.WriteLine(ConstantMessages.BankId);
                string bId = Console.ReadLine();
                Console.WriteLine(ConstantMessages.AccountId);
                string aId = Console.ReadLine();
                string pass = InputTakenFromUser.Password();
                try
                {
                    bankstaff = bankmanager.Stafflogin(aId, pass, bId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto LoginPage;
                }
                ConsoleOutput.WelcomeUser();
            // login successful

            StaffOperations:
                ConsoleOutput.StaffChoice();
                OperationsPerdormedByStaff staffoperation;
                try
                {
                    staffoperation = (OperationsPerdormedByStaff)Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto StaffOperations;
                }
                while (staffoperation!=OperationsPerdormedByStaff.Quit)
                {
                    Account BankAccount;

                    if (staffoperation==OperationsPerdormedByStaff.CreateAccount)
                    {
                        int choice;
                        string name, pasword, Id;
                        try
                        {
                            Console.WriteLine(ConstantMessages.CreateAccountChoice);
                            choice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(ConstantMessages.BankId);
                            BankId = Console.ReadLine();
                            name = InputTakenFromUser.Username();
                            password = InputTakenFromUser.Password();

                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                            goto StaffOperations;
                        }
                        try
                        {
                            Id = staffmanager.CreateAccount(BankId, name, password, choice);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }

                        ConsoleOutput.AccountId(Id);
                        ConsoleOutput.AccountSuccessfullCreation();
                    }
                    else if (staffoperation == OperationsPerdormedByStaff.UpdateAccountStatus)
                    {
                        Console.Clear();
                    UpdateAccount:
                        Console.WriteLine(ConstantMessages.UpdateDeleteAccount);
                        string choice = Console.ReadLine();
                        //update
                        if (choice=="1")
                        {
                            int option;
                            string userId, bankId;
                            try
                            {
                                Console.WriteLine(ConstantMessages.AccountUpdateChoice);
                                option = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(ConstantMessages.AccountId);
                                userId = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId = Console.ReadLine();
                                BankAccount = staffmanager.UpdateChanges(bankId, userId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto UpdateAccount;
                            }
                            if (option == 1)
                            {
                                Console.WriteLine(ConstantMessages.Name);
                                BankAccount.name = Console.ReadLine();
                            }
                            else if (option==2)
                            {
                                Console.WriteLine(ConstantMessages.Password);
                                BankAccount.password = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid option");
                                goto UpdateAccount;
                            }

                        }
                        //delete
                        else if (choice=="2")
                        {
                            string userId, bankId;
                            try
                            {
                                Console.WriteLine(ConstantMessages.AccountId);
                                userId = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto UpdateAccount;
                            }
                            try
                            {
                                staffmanager.DeleteAccount(bankId, userId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto UpdateAccount;
                            }
                            Console.WriteLine(ConstantMessages.AccountSuccessfullDeletion);
                        }
                        else
                        {
                            ConsoleOutput.InValidOption();
                            goto UpdateAccount;
                        }
                    }

                    else if (staffoperation== OperationsPerdormedByStaff.ChangeCurrency)
                    {
                        string code;
                        double rate;
                        try
                        {
                            Console.WriteLine(ConstantMessages.NewCurrencyCode);
                            code = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ExchangeRate);
                            rate = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                            goto StaffOperations;
                        }
                        staffmanager.AddCurrency(code, rate);
                    }


                    else if (staffoperation== OperationsPerdormedByStaff.AccountCharges)
                    {
                    UpdateServiceCharge:
                        Console.WriteLine(ConstantMessages.ServiceChargeUpdateChoice);
                        string choice = Console.ReadLine();
                        // same
                        if (choice == "1")
                        {
                            double rtgs, imps;
                            try
                            {
                                Console.WriteLine(ConstantMessages.NewRTGScharge);
                                rtgs = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine(ConstantMessages.NewIMPScharge);
                                imps = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                goto UpdateServiceCharge;
                            }
                            staffmanager.UpdateCharges(rtgs, imps, 1);
                        }
                        // different
                        else if (choice == "2")
                        {
                            double rtgs, imps;
                            try
                            {
                                Console.WriteLine(ConstantMessages.NewRTGScharge);
                                rtgs = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine(ConstantMessages.NewIMPScharge);
                                imps = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                goto UpdateServiceCharge;
                            }
                            staffmanager.UpdateCharges(rtgs, imps, 2);
                        }
                        else
                        {
                            ConsoleOutput.InValidOption();
                            goto UpdateServiceCharge;
                        }

                    }

                    else if (staffoperation== OperationsPerdormedByStaff.TransactionHistory)
                    {
                        Console.Clear();
                    ShowTransactionHistory:
                        Console.WriteLine(ConstantMessages.AccountId);
                        string acountId = Console.ReadLine();
                        BankAccount = staffmanager.ViewHistory(accountId);
                        if (BankAccount == null)
                        {
                            Console.WriteLine(ConstantMessages.InvalidDetail);
                            goto ShowTransactionHistory;
                        }
                        foreach (var i in BankAccount.Transactions)
                        {
                            ConsoleOutput.TransactionHistory(i);
                        }
                    }
                    else if (staffoperation== OperationsPerdormedByStaff.RevertTransaction)
                    {
                        Console.WriteLine("Done Later");
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleOutput.InValidOption();
                    }
                    goto StaffOperations;
                }
                Console.Clear();

            }
            // login part
            else if (loginOptions == LoginType.Customerlogin)
            {
            CustomerOperations:

                CustomerOption option;
                try
                {
                    option = (CustomerOption)Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CustomerOperations;
                }
                ConsoleOutput.option();
                if (option == CustomerOption.CreateAccount)
                {

                    string name, pasword, Id;
                    try
                    {
                        Console.WriteLine(ConstantMessages.CreateAccountChoice);
                        choice1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(ConstantMessages.BankId);
                        BankId = Console.ReadLine();
                        username = InputTakenFromUser.Username();
                        password = InputTakenFromUser.Password();

                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);

                    }
                    try
                    {
                        accountId = staffmanager.CreateAccount(BankId, username, password, choice1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                    ConsoleOutput.AccountId(accountId);
                    ConsoleOutput.AccountSuccessfullCreation();
                }
                else if (option==CustomerOption.Login)
                {
                    Account BankAccount;
                    Console.WriteLine(ConstantMessages.BankId);
                    string bId = Console.ReadLine();
                    Console.WriteLine(ConstantMessages.AccountId);
                    string aId = Console.ReadLine();
                    string pass = InputTakenFromUser.Password();
                    try
                    {
                        BankAccount = bankmanager.userlogin(aId, pass, bId);
                    }
                    catch
                    {
                        Console.WriteLine(ConstantMessages.InvalidDetail);
                        goto LoginPage;
                    }
                    if (BankAccount == null)
                    {
                        Console.WriteLine(ConstantMessages.InvalidDetail);
                        goto LoginPage;
                    }
                    else
                    {
                        Console.WriteLine(ConstantMessages.SuccessfullLogin);
                    }
                CoustomerOperations:

                    ConsoleOutput.CustomerChoice();
                    OperationsPerformedByUser customerOperation;
                    try
                    {
                        customerOperation = (OperationsPerformedByUser)Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto CustomerOperations;
                    } //////////
                    while (customerOperation != OperationsPerformedByUser.Logout)
                    {

                        if (customerOperation == OperationsPerformedByUser.deposit)
                        {
                            Console.Clear();
                            double amt;
                            string currCode, bankId , accId;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.DepositAmount());
                                Console.WriteLine(ConstantMessages.CurrencyCode);
                                currCode = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.AccountId);
                                accId = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            try
                            {
                                AccountManager.deposit( amt,accId,  currCode , bankId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            ConsoleOutput.DepositSuccessfull(amt);
                        }
                        else if (customerOperation == OperationsPerformedByUser.withdraw)
                        {
                            Console.Clear();
                            double amt;
                            string bankId , accId;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.WithdrawAmount());
                                Console.WriteLine(ConstantMessages.AccountId);
                                accId = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId=Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            if (AccountManager.withdraw( amt, accId , BankAccount, bankId))
                            {
                                ConsoleOutput.WithdrawSuccessfull(amt);
                            }
                            else
                            {
                                ConsoleOutput.InsufficientBalance();
                            }
                        }
                        else if (customerOperation == OperationsPerformedByUser.transfer)
                        {
                            Console.Clear();
                         //   Account reciever;
                            Console.WriteLine(ConstantMessages.SenderBankId);
                            string sbankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ReceiverBankId);
                            string ToBankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ServiceChargeType);
                            string choice = Console.ReadLine();
                            Console.WriteLine("Please enter sender account Id");
                            string sid = Console.ReadLine();
                            Console.WriteLine("Please enter Reciever account Id");
                            string rid = Console.ReadLine();
                           
                            if (reciever != null)
                            {
                                Console.WriteLine(ConstantMessages.Amount);
                                double amtToTransfer = Convert.ToDouble(Console.ReadLine());
                                if (AccountManager.transfer( amtToTransfer,sid , rid,sbankId,  ToBankId, choice))
                                {
                                    ConsoleOutput.TransferSuccessfull(amtToTransfer);
                                }
                                else
                                {
                                    Console.WriteLine(ConstantMessages.InvalidDetail);
                                }
                            }
                            else
                            {
                                Console.WriteLine(ConstantMessages.AccountDoesNotExist);
                            }

                        }
                        else if (customerOperation == OperationsPerformedByUser.transactionHistory)
                        {
                            Console.Clear();
      
                            foreach (var i in BankAccount.Transactions)
                            {
                                ConsoleOutput.TransactionHistory(i);
                            }

                        }
                     
                        else if (customerOperation == OperationsPerformedByUser.Login)
                        {
                            goto LoginPage;
                        }
                        else
                        {
                            Console.Clear();
                            ConsoleOutput.InValidOption();
                        }
                        goto CustomerOperations;
                    }
                }
            }
            else
            {
                Console.Clear();
                ConsoleOutput.InValidOption();
                goto LoginPage;
            }
        ////
        // Console.WriteLine(ConstantMessages.BankId);
        Finish:
            ConsoleOutput.Exit();
        }
    }
}
