
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
  public  class Staff : Parent// use one parent class for account holder and staff as they have multiple common properties
    {

        public Dictionary<string, string> stafflogin;

      
        //public Staff( string Name , string Password , string Id)
        //{
        //    this.Name = Name;
        //    this.Password = Password;
        //    this.Id = Id;
        //    stafflogin = new Dictionary<string, string>();
        //    this.dateTime= DateTime.Now;
            
        //}
        
        public Bank Bank { get; set; }
        
        public string BankId { get; set; }
    }
}
