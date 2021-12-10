using System;
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
     //   [Key][Required]
        public Bank Bank { get; set; }
       // [Key][Required]
           [Required]
        public string RecieverBankId { get; set; }

        public Account Account { get; set; }
    //   public Account ReceiverAccount { get; set; }
        //[Key][Required]
       public double Amount { get; set; }
    //    [Key][Required]
        public DateTime TransactionOn { get; set; } // rename CreatedOn/ TransactionOn
      //  [Key][Required]
        public TransactionType type { get; set; } // use same notation for property names mostly we use Camelcase
        //[Key][Required][StringLength(50)]
        public string TransactionId{get;set;}
      //  public Account Account { get; set; }
        // [Key][Required]
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
