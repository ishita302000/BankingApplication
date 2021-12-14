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
           
            string accountId = "";
         
            string BankId = "";
            string Bankname = "";
            string CountryCode = "";
        
            string StaffName = "";
            string Staffpass = "";
            

            ConsoleOutput.Welcome();

            CommanServices bankmanager = new CommanServices();
            StaffServices staffmanager = new StaffServices();
            Console.WriteLine(ConstantMessages.SetupFirstBank);

        SetupBank:

            string bankName = InputTakenFromUser.BankName();
            string branch = InputTakenFromUser.branch();
            Console.WriteLine(ConstantMessages.CurrencyCode);
            string currencyCode = Console.ReadLine();
            string bankID;
            try
            {
                bankID = staffmanager.CreateBank(bankName,branch,  currencyCode);
                ConsoleOutput.BankSuccessfullCreation();
                ConsoleOutput.BankId(bankID);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto SetupBank;
            }
            Console.WriteLine(ConstantMessages.CreateFirstStaff);

            CustomerServices AccountManager = new CustomerServices( );  //check
        SetupStaff:
            Console.WriteLine(ConstantMessages.StaffName);
            StaffName = Console.ReadLine();
            Staffpass = InputTakenFromUser.Password();
            string StaffaccountID;
            try
            {
                StaffaccountID = staffmanager.CreateAccount(bankID, StaffName, Staffpass , 1);
                ConsoleOutput.AccountId(StaffaccountID);
                ConsoleOutput.WelcomeUser();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetupStaff;
            }
        LoginPage:
            ConsoleOutput.Login();
            LoginType loginOption;
            try
            {
                
                loginOption = (LoginType)(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto LoginPage;
            }
           

            if (loginOption == LoginType.BankSetup)
            {
                Console.WriteLine(" Bank Set Up "); // use constants
                goto SetupBank;

            }
            else if (loginOption == LoginType.Stafflogin)
            {

                Console.WriteLine(" Staff Login "); // use constants
                Staff bankstaff;
                Console.WriteLine(ConstantMessages.BankId);
                bankID = Console.ReadLine();
                Console.WriteLine(ConstantMessages.AccountId);
                accountId = Console.ReadLine();
                string pass = InputTakenFromUser.Password();
                try
                {
                    bankstaff = bankmanager.Stafflogin(accountId, pass, bankID);
                    if (bankstaff == null)
                    {
                        throw new Exception(ConstantMessages.AccountDoesNotExist);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto LoginPage;
                }
                ConsoleOutput.WelcomeUser();

            StaffOperations:
                ConsoleOutput.StaffChoice();
                OperationsPerdormedByStaff staffOperation;
                try
                {
                    staffOperation = (OperationsPerdormedByStaff)Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto StaffOperations;
                }
                while (staffOperation != OperationsPerdormedByStaff.LogOut)
                {
                    Account bankAccount;
                    if (staffOperation == OperationsPerdormedByStaff.CreateAccount) // use swich case
                    {
                        int choice;
                        string bankId, name, password, Id;

                        try
                        {
                            Console.WriteLine(ConstantMessages.CreateAccountChoice);
                            choice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(ConstantMessages.BankId);
                            bankId = Console.ReadLine();
                            name = InputTakenFromUser.Username();
                            password = InputTakenFromUser.Password();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }
                        try
                        {
                            Id = staffmanager.CreateAccount(bankId, name, password, choice);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }

                        ConsoleOutput.AccountId(Id);
                        ConsoleOutput.AccountSuccessfullCreation();

                    }
                    else if (staffOperation == OperationsPerdormedByStaff.UpdateAccountStatus)
                    {
                        Account account;
                      //  Console.Clear();
                    UpdateAccount:
                        Console.WriteLine(ConstantMessages.UpdateDeleteAccount);
                        string choice1 = Console.ReadLine();
                        if (choice1 == "1") 
                        {
                            int userChoice;
                            string userId, bankId;
                            try
                            {
                                Console.WriteLine(ConstantMessages.AccountUpdateChoice);
                                userChoice = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(ConstantMessages.AccountId);
                                userId = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId = Console.ReadLine();
                                bankAccount = staffmanager.GetAccountById(bankId , userId);
                                 staffmanager.UpdateAccount(bankAccount);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                                goto UpdateAccount;
                            }

                            switch (userChoice)
                            {
                                case 1:
                                    Console.WriteLine(ConstantMessages.Name);
                                    bankAccount.Name = Console.ReadLine();
                                    break;
                                case 2:
                                    bankAccount.Password = InputTakenFromUser.Password();
                                    break;
                                default:
                                    ConsoleOutput.InValidOption();
                                    goto UpdateAccount;
                            }

                        }
                        else if (choice1 == "2")
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

                    else if (staffOperation == OperationsPerdormedByStaff.ChangeCurrency)
                    {
                        string code , bankId;
                        double rate;
                        Currency currency = new Currency();   // check
                        try
                        {
                            Console.WriteLine(ConstantMessages.BankId);
                            bankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.NewCurrencyCode);
                            code = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ExchangeRate);
                            rate = Convert.ToDouble(Console.ReadLine());
                            
                            staffmanager.AddCurrency(currency);   // check exchange rate

                            currency =staffmanager.GetCurrencyByName(bankId , code);   // check
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }
                    }


                    else if (staffOperation == OperationsPerdormedByStaff.UpdateServiceCharge)
                    {
                    UpdateServiceCharge:
                        Console.WriteLine(ConstantMessages.ServiceChargeUpdateChoice);
                        string choice = Console.ReadLine();
                        if (choice == "1")// use switch case & maintain choice in enum
                        {
                            double rtgs, imps;
                            try
                            {
                                Console.WriteLine(ConstantMessages.NewRTGScharge);
                                rtgs = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine(ConstantMessages.NewIMPScharge);
                                imps = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto UpdateServiceCharge;
                            }
                            staffmanager.UpdateCharges(rtgs, imps, 1);
                        }
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
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
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
                    else if (staffOperation == OperationsPerdormedByStaff.TransactionHistory)
                    {
                      //  Console.Clear();

                    ShowTransactionHistory:
                        Console.WriteLine(ConstantMessages.AccountId);
                        string acountId = Console.ReadLine();
                        bankAccount = staffmanager.ViewHistory(accountId);
                        if (bankAccount == null)
                        {
                            Console.WriteLine(ConstantMessages.InvalidDetail);
                            goto ShowTransactionHistory;
                        }
                        foreach (var i in bankAccount.Transactions)
                        {
                            ConsoleOutput.TransactionHistory(i);
                        }
                    }
                    else if (staffOperation == OperationsPerdormedByStaff.RevertTransaction)
                    {
                        Console.WriteLine("Done Later");
                    }
                    else if (staffOperation == OperationsPerdormedByStaff.LoginAnotherAccount)
                    {
                        goto LoginPage;
                    }
                  
                   else
                    {
                        Console.Clear();
                        ConsoleOutput.InValidOption();
                    }
                    goto StaffOperations;
                }
                Console.Clear();
                goto Finish;

            }
            else if (loginOption == LoginType.Customerlogin)
            {
                Console.WriteLine(" Customer Log in ");

                Account bankAccount;
        //        Console.Clear();

                Console.WriteLine(ConstantMessages.BankId);
                string bId = Console.ReadLine();
                Console.WriteLine(ConstantMessages.AccountId);
                string aId = Console.ReadLine();
                string pass = InputTakenFromUser.Password();
                try
                {
                    bankAccount = bankmanager.userlogin( aId, pass, bId);
                }
                catch
                {
                    Console.WriteLine(ConstantMessages.InvalidDetail);
                    goto LoginPage;
                }
                if (bankAccount == null)
                {
                    Console.WriteLine(ConstantMessages.InvalidDetail);
                    goto LoginPage;
                }
                else
                {
                    Console.WriteLine(ConstantMessages.SuccessfullLogin);
                CustomerOperations:
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
                    }
                    while (customerOperation != OperationsPerformedByUser.LogOut)
                    {
                        if (customerOperation == OperationsPerformedByUser.Deposit)
                        {
                          //  Console.Clear();
                            double amt;
                            string currCode, bankId , accId;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.DepositAmount());
                                Console.WriteLine(ConstantMessages.CurrencyCode);
                                currCode = Console.ReadLine();
                                Console.WriteLine(ConstantMessages.BankId);
                                bankId = Console.ReadLine();
                          //      Console.WriteLine(ConstantMessages.AccountId);
                            //    accId = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            try
                            {
                                AccountManager.deposit(  amt,bankAccount,  currCode, bankId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            ConsoleOutput.DepositSuccessfull(amt);
                        }
                        else if (customerOperation == OperationsPerformedByUser.Withdraw)
                        {
                          //  Console.Clear();
                            double amt;
                            string bankId , accId;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.WithdrawAmount());
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
                            if ( AccountManager.withdraw( amt, accId , bankAccount, bankId ))
                            {
                                ConsoleOutput.WithdrawSuccessfull(amt);
                            }
                            else
                            {
                                ConsoleOutput.InsufficientBalance();
                            }
                        }
                        else if (customerOperation == OperationsPerformedByUser.Transfer)
                        {
                         //   Console.Clear();
                            Account reciever;
                            Console.WriteLine(ConstantMessages.SenderBankId);
                            string sbankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ReceiverBankId);
                            string ToBankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ServiceChargeType);
                            string choice = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.TransferToAccountHolderName);
                            string ReceiverName = Console.ReadLine();
                            string receiveraccId = staffmanager.GetAccountIdByname(ToBankId , ReceiverName);
                            try
                            {
                                reciever = staffmanager.CheckAccountExistance(ToBankId, receiveraccId);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            if (reciever != null)
                            {
                                Console.WriteLine(ConstantMessages.Amount);
                                double amtToTransfer = Convert.ToDouble(Console.ReadLine());
                                if (AccountManager.transfer( amtToTransfer,sbankId  , ToBankId , sbankId, ToBankId, choice , currencyCode))
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
                        else if (customerOperation == OperationsPerformedByUser.TransactionHistory)
                        {
                         //   Console.Clear();

                            foreach (var i in bankAccount.Transactions)
                            {
                                ConsoleOutput.TransactionHistory(i);
                            }

                        }
                        else if(customerOperation == OperationsPerformedByUser.Balance)
                        {
                            ConsoleOutput.Balance();
                            Console.Write(bankmanager.viewbalance(bankAccount));
                        }

                        else if (customerOperation == OperationsPerformedByUser.LoginAnotherAccount)
                        {
                            goto LoginPage;
                        }
                        else
                        {
                         //   Console.Clear();
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
         //   Console.Clear();
        Finish:
            ConsoleOutput.Exit();
        }
    }
}
