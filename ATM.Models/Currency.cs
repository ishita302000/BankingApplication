using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
   public class Currency // why disctionary use one currency class which have Code, ExchangeRate, bank details properties
    { 
        public string BankId { get; set; }
        public double ExchangeRate { get; set; }
        public string Code { get; set; }
    }
}
