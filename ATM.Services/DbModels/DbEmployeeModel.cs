using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
    public class DbEmployeeModel
    {
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string EmployeeId { get; set; }
        public string BankId { get; set; }
        public DbBankModel Bank{get;set;}
    }
}
