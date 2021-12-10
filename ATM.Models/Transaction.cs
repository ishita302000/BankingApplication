﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
   public  class Transaction 
    {
        [Required]
        public string RecieverAccountId { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public Bank Bank { get; set; }
  
        [Required]
        public string RecieverBankId { get; set; }

        public Account Account { get; set; }
    //   public Account ReceiverAccount { get; set; }
        [Required]
       public double Amount { get; set; }
        [Required]
        public DateTime TransactionOn { get; set; } // rename CreatedOn/ TransactionOn
        [Required]
        public TransactionType type { get; set; } // use same notation for property names mostly we use Camelcase
        [Required]
        public string TransactionId{get;set;}
        [Required]
        public string date { get; set; }
        public Transaction()
        {

        }
        public Transaction( string RecieverAccountId, string SenderAccountId,  double Amount, DateTime TransactionOn, TransactionType type, string SenderBankId , string RecieverBankId)
        {
            this.RecieverAccountId = RecieverAccountId;
            this.AccountId = SenderAccountId;
            this.RecieverBankId = RecieverBankId;
            this.BankId = SenderBankId;
            this.Amount = Amount;
            this.TransactionOn = TransactionOn;
            this.type = (TransactionType)type;
            date = TransactionOn.ToString();
            TransactionId = "";
            TransactionId = "TXN" + SenderBankId + SenderAccountId + date;
        }
    }
}
