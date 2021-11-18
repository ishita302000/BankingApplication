
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
  public  class Staff
    {
        public string StaffId { get;
            set;
        }
        public string Name
        {
            get; set;
        }
        public string Password
        {
            get; set;
         }
        private DateTime CurrentDate { get; set; }
        public StaffLoginType Access
        {
            get; set;
         }
        public Dictionary<string, string> stafflogin;
         
        public Staff(string Name , string Password , StaffLoginType Access = StaffLoginType.StaffMember)
        {    
            this.Name = Name;
            this.Password = Password;
            CurrentDate = DateTime.Now;
            string Date = CurrentDate.ToShortDateString();
            stafflogin = new Dictionary<string, string>();
            for(int i=0;i<3;i++)
            {
                StaffId += Name[i];
            }
            StaffId += Date;  // staffmember
            Access = StaffLoginType.StaffMember;
            this.Access = Access;
        }
    }
}
