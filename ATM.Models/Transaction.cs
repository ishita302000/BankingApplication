using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
    class Transaction
    {
        public string RecieverAccountId;
        public string SenderAccountId;
        public string BankId;
        public double Amount;
        public DateTime On;
        public TransactionType type;
        public string Id;
        public string date;
        public Transaction(string RecieverAccountId, string SenderAccountId, string BankId, double Amount, DateTime On, TransactionType type)
        {
            this.RecieverAccountId = RecieverAccountId;
            this.RecieverAccountId = SenderAccountId;
            this.Amount = Amount;
            this.On = On;
            this.type = type;
            date = On.ToString();
            Id = "TXN" + BankId + SenderAccountId + date;
        }
    }
}
