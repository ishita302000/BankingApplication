using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
   public class Currency // why disctionary use one currency class which have Code, ExchangeRate, bank details properties
    { 
        [Key][Required]
        public int Id { get; set; }
        public Bank Bank { get; set; }
        public string BankId { get; set; }
        public static Dictionary<string, double> curr = new Dictionary<string, double>()
        {
            { "EUR", 85.71},
            { "INR", 1.00},
            { "USD", 73.89}
        };
    }
}
