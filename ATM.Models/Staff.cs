
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
  public  class Staff : Parent// use one parent class for account holder and staff as they have multiple common properties
    {
     
        public Dictionary<string, string> stafflogin;
         
        public Staff()
        {   
            stafflogin = new Dictionary<string, string>();
            
        }
    }
}
