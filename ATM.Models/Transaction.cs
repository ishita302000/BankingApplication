using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
   public  class Transaction 
    {
        [Key][Required]
        public Account RecieverAccountId { get; set; }
        [Key][Required]
        public Account SenderAccountId { get; set; }
        [Key][Required]
        public Bank SenderBankId { get; set; }
        [Key][Required]
        public Bank SenderBank { get; set; }
        [Key][Required]
        public Bank RecieverBank { get; set; }
        [Key][Required]
        public Bank RecieverBankId { get; set; }
        [Key][Required]
        public Bank Bank { get; set; }
        [Key][Required]
        public Account Account { get; set; }
        [Key][Required]
        public double Amount { get; set; }
        [Key][Required]
        public DateTime TransactionOn { get; set; } // rename CreatedOn/ TransactionOn
        [Key][Required]
        public TransactionType type { get; set; } // use same notation for property names mostly we use Camelcase
        [Key][Required][StringLength(50)]
        public string TransactionId{get;set;}
        [Key][Required]
        public string date { get; set; }
        public Transaction( Account RecieverAccountId, Account SenderAccountId,  double Amount, DateTime TransactionOn, TransactionType type, Bank SenderBankId , Bank RecieverBankId)
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
