using System;
using System.Collections.Generic;
using ATM.Models;
using ATM.Models.Enums;
using ATM.Models.Exceptions;
using ATM.Services;
using ATM.Services.DbModels;
using ATM.Services.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.CLI
{
    class Program
    {
        public static readonly IServiceProvider services = DIBuilder.Build();
        static void Main(string[] args)
        {
            string accountId = "";
            string StaffName = "";
            string Staffpass = "";         
            ConsoleOutput.Welcome();

            ICommanServices commanService = services.GetService<ICommanServices>();
            ICustomerServices customerService = services.GetService<ICustomerServices>();
            IDbServices dbService = services.GetService<IDbServices>();
            


            Console.WriteLine(ConstantMessages.SetupFirstBank);

        SetupBank:

            string bankName = InputTakenFromUser.BankName();
            string branch = InputTakenFromUser.branch();
            Console.WriteLine(ConstantMessages.CurrencyCode);
            string currencyCode = Console.ReadLine();
            string bankID;
            Bank bank;
            try
            {
                bank = dbService.CreateBank(bankName,branch,  currencyCode); // check
                dbService.AddBank(bank);
                ConsoleOutput.BankSuccessfullCreation();
                ConsoleOutput.BankId(bank.Id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto SetupBank;
            }
            Console.WriteLine(ConstantMessages.CreateFirstStaff);

        SetupStaff:
            Console.WriteLine(ConstantMessages.StaffName);
            StaffName = Console.ReadLine();
            Staffpass = InputTakenFromUser.Password();
            string StaffAccountID;
            try
            {
               Employee Staffaccount = dbService.CreateStaffAccount(bank.Id, StaffName, Staffpass);
              //  StaffAccountID=dbService.GetStaffIdByname(bank.Id , StaffName);
                dbService.AddStaff(Staffaccount);
                ConsoleOutput.AccountId(Staffaccount.EmployeeId);
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
        //        Console.WriteLine(" Bank Set Up "); // use constants
                goto SetupBank;

            }
            else if (loginOption == LoginType.Stafflogin)
            {

          //      Console.WriteLine(" Staff Login "); // use constants
                Employee bankstaff;
                Console.WriteLine(ConstantMessages.BankId);
                bankID = Console.ReadLine();
                Console.WriteLine(ConstantMessages.AccountId);
                accountId = Console.ReadLine();
                string pass = InputTakenFromUser.Password();
                try
                {
                    bankstaff = commanService.Stafflogin(accountId, pass, bankID);
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
                    Customer bankAccount;
                    if (staffOperation == OperationsPerdormedByStaff.CreateAccount) // use swich case
                    {
                        int choice;
                        string bankId, name, password;
                        string Id;

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
                            Customer account = dbService.CreateCustomerAccount(bankId, name, password, 2);
                            
                            dbService.AddAccount(account);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }
                        try
                        {
                            Employee acc = dbService.CreateStaffAccount(bankId, name, password);
                            dbService.AddStaff(acc);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            goto StaffOperations;
                        }
                        Id = dbService.GetAccountIdByname(bankId,name);
                        ConsoleOutput.AccountId(Id);
                        ConsoleOutput.AccountSuccessfullCreation();

                    }
                    else if (staffOperation == OperationsPerdormedByStaff.UpdateAccountStatus)
                    {
                        Customer account;
                      //  Console.Clear();
                    UpdateAccount:
                        Console.WriteLine(ConstantMessages.UpdateDeleteAccount);  // 1 update 2 delete
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
                                bankAccount = dbService.GetAccountById(bankId , userId);
                                 dbService.UpdateAccount(bankAccount);
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
                                dbService.DeleteAccount(bankId, userId);
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

                    else if (staffOperation == OperationsPerdormedByStaff.ChangeCurrency) //Add currency
                    {
                        string code , bankId;
                        double rate;
                        Currency currency;   // check
                        try
                        {
                            Console.WriteLine(ConstantMessages.BankId);
                            bankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.NewCurrencyCode);
                            code = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ExchangeRate);
                            rate = Convert.ToDouble(Console.ReadLine());
                            currency = new Currency {
                                Code = code,
                                BankId = bankId,
                                ExchangeRate = rate
                            };
                            dbService.AddCurrency(currency);   // check exchange rate

                          //  currency =DbService.GetCurrencyByName(bankId , code);   // check
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
                        Console.WriteLine(ConstantMessages.ServiceChargeUpdateChoice);  // 1 same bank 2 different bank
                        string choice = Console.ReadLine();
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
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto UpdateServiceCharge;
                            }
                            dbService.UpdateCharges(rtgs, imps, 1 , bankID);
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
                            dbService.UpdateCharges(rtgs, imps, 2 , bankID);
                        }
                        else
                        {
                            ConsoleOutput.InValidOption();
                            goto UpdateServiceCharge;
                        }
                    }
                    else if (staffOperation == OperationsPerdormedByStaff.TransactionHistory)
                    {

                    ShowTransactionHistory:
                        Console.WriteLine(ConstantMessages.AccountId);
                        string AccId = Console.ReadLine();
                        bankAccount = dbService.ViewHistory(AccId);       // gettransactions
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
      //          Console.WriteLine(" Customer Log in ");

                Customer bankAccount;
        //        Console.Clear();

                Console.WriteLine(ConstantMessages.BankId);
                string bId = Console.ReadLine();
                Console.WriteLine(ConstantMessages.AccountId);
                string aId = Console.ReadLine();
                string pass = InputTakenFromUser.Password();
                try
                {
                    bankAccount = commanService.userlogin( aId, pass, bId);
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
                            Transaction transaction;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.DepositAmount());
                                Console.WriteLine(ConstantMessages.CurrencyCode);
                                currCode = Console.ReadLine();
                                customerService.Deposit(amt, bankAccount, currCode);
                                transaction = new Transaction {
                                    SrcAccount = bankAccount.CustomerId,
                                    Id = bankAccount.BankId.GenTransactionId(bankAccount.CustomerId),
                                    Amount = amt,
                                    CreatedOn = DateTime.Now
                                };
                                    dbService.AddTransaction(transaction);
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
                            Transaction transaction;
                            try
                            {
                                amt = Convert.ToDouble(InputTakenFromUser.WithdrawAmount());
                                /*   Console.WriteLine(ConstantMessages.BankId);
                                   bankId = Console.ReadLine();
                                   Console.WriteLine(ConstantMessages.AccountId);
                                   accId = Console.ReadLine();*/
                                 //check
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                goto CustomerOperations;
                            }
                            if ( customerService.Withdraw( amt, bankAccount ))
                            {
                                transaction = new Transaction {
                                    SrcAccount = bankAccount.CustomerId,
                                    Id = bankAccount.BankId.GenTransactionId(bankAccount.CustomerId),
                                    Amount = amt,
                                    CreatedOn = DateTime.Now
                                };
                                dbService.AddTransaction(transaction);   //check
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
                            Customer reciever;
                            Transaction transaction;
                            Console.WriteLine(ConstantMessages.SenderBankId);
                            string sbankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ReceiverBankId);
                            string ToBankId = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.ServiceChargeType);
                            string choice = Console.ReadLine();
                            Console.WriteLine(ConstantMessages.TransferToAccountHolderName);
                            string ReceiverName = Console.ReadLine();
                            string receiveraccId = dbService.GetAccountIdByname(ToBankId , ReceiverName);
                            try
                            {
                                reciever = dbService.CheckAccountExistance(ToBankId, receiveraccId);
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
                                if (customerService.transfer( amtToTransfer , aId , receiveraccId , sbankId, ToBankId, choice , currencyCode))
                                {
                                    ConsoleOutput.TransferSuccessfull(amtToTransfer);
                                    transaction = new Transaction {
                                        SrcAccount = bankAccount.CustomerId,
                                        Id = bankAccount.BankId.GenTransactionId(bankAccount.CustomerId),
                                        Amount = amtToTransfer,
                                        CreatedOn = DateTime.Now
                                    };
                                    dbService.AddTransaction(transaction);        //check
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
                            Console.Write(commanService.viewbalance(bankAccount));
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
