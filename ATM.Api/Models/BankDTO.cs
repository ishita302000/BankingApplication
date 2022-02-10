using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Models
{
    public class BankDTO 
    {
        public string BankName { get; set; }
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public double RTGSsameBank { get; set; } = 0;
        public double RTGSdifferentBank { get; set; } = .02;
        public double IMPSsameBank { get; set; } = 0.5;
        public double IMPSdifferentBank { get; set; } = .06;
    }
}