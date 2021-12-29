
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
        public string Salary { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Id { get; set; }
        public string EmployeeId { get; set; }
       
    }
}
