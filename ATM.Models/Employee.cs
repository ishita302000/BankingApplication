
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Models
{
  public  class Employee // use one parent class for account holder and staff as they have multiple common properties
    { 
        public string Name { get; set; }
        public decimal Salary { get; set; } = 20000;
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string EmployeeId { get; set; }
        public string BankId { get; set; }
       
    }
}
