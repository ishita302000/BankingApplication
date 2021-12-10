using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
    public class DbCurrencyModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public Bank Bank { get; set; }
        [Required]
        public string BankId { get; set; }
        [Required]
        public double exchangerate { get; set; }
        [Required]
        public string code { get; set; }
    }
}
