using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Models
{
    public class EmployeeCreateDTO 
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string BankId { get; set; }
    }
}