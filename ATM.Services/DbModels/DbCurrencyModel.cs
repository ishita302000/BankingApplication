using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
    public class DbCurrencyModel
    {
        public int Id { get; set; }
        public double ExchangeRate { get; set; }
        public string Code { get; set; }
    }
}
