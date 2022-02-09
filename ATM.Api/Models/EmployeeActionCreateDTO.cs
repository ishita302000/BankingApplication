using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Models
{
    public class EmployeeActionCreateDTO 
    {
        public string? TXNId { get; set; }
        public string? AccountId { get; set; }
        public string BankId { get; set; }
        public string EmployeeId { get; set; }
    }
}