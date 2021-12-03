using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
   public  class Transaction 
    {
        
        public Account RecieverAccountId { get; set; }
        public Account SenderAccountId { get; set; }
        public Bank SenderBankId { get; set; }
        public Bank RecieverBankId { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionOn { get; set; } // rename CreatedOn/ TransactionOn
        public TransactionType type { get; set; } // use same notation for property names mostly we use Camelcase
        public string TransactionId{get;set;}
        public string date { get; set; }
        public Transaction(Account RecieverAccountId, Account SenderAccountId,  double Amount, DateTime TransactionOn, TransactionType type, Bank SenderBankId , Bank RecieverBankId)
        {
            this.RecieverAccountId = RecieverAccountId;
            this.SenderAccountId = SenderAccountId;
            this.RecieverBankId = RecieverBankId;
            this.SenderBankId = SenderBankId;
            this.Amount = Amount;
            this.TransactionOn = TransactionOn;
            this.type = (TransactionType)type;
            date = TransactionOn.ToString();
            TransactionId = "";
            TransactionId = "TXN" + SenderBankId + SenderAccountId + date;
        }
    }
}
