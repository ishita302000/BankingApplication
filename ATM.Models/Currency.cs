using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
   public class Currency // why disctionary use one currency class which have Code, ExchangeRate, bank details properties
    { 
    //    [Key][Required]
        public int Id { get; set; }
      //  [Key][Required]
        public Bank Bank { get; set; }
        //[Key][Required]
        public string BankId { get; set; }
      //  [Key][Required]
        public double exchangerate { get; set; }
        //[Key][Required]
        public string code { get; set; }
    }
}
