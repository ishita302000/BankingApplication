using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Models
{
    public class CreditAmountDTO 
    {
        public decimal Amount { get; set; }
        public string CurrencyName { get; set; }
    }
}