using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ATM.Api.Models
{
    public class TransactionCreateDTO
    {
        public string? ToBankId { get; set; }
        public string? ToAccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
    }
}