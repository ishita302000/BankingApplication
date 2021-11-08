using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
   public  class Transaction
    {
        
        public string RecieverAccountId { get; set; }
        public string SenderAccountId { get; set; }
        public string SenderBankId { get; set; }
        public string RecieverBankId { get; set; }
        public double Amount { get; set; }
        public DateTime On { get; set; }
        public TransactionType type { get; set; }
        public string TransactionId{get;set;}
        public string date { get; set; }
        public Transaction(string RecieverAccountId, string SenderAccountId,  double Amount, DateTime On, TransactionType type, String SenderBankId , String RecieverBankId)
        {
            this.RecieverAccountId = RecieverAccountId;
            this.SenderAccountId = SenderAccountId;
            this.RecieverBankId = RecieverBankId;
            this.SenderBankId = SenderBankId;
            this.Amount = Amount;
            this.On = On;
            this.type = (TransactionType)type;
            date = On.ToString();
            TransactionId = "";
            TransactionId = "TXN" + SenderBankId + SenderAccountId + date;
        }
    }
}
