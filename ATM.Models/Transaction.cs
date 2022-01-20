using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public  class Transaction 
    {      
        public string SrcAccount{ get; set; }
        public string DepAccount { get; set; }
        public string  Id { get; set; }   
        public double Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
