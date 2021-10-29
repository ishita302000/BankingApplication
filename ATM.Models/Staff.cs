
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
  public  class Staff
    {
        public string StaffId;
        public string Name;
        public string Password;
        private DateTime CurrentDate;
        public StaffLoginType Access;
         
        public Staff(string Name , string Password , StaffLoginType Access)
        {    
            this.Name = Name;
            this.Password = Password;
            CurrentDate = DateTime.Now;
            for(int i=0;i<3;i++)
            {
                StaffId += Name[i];
            }
            StaffId += CurrentDate;
            Access = StaffLoginType.StaffMember;
            this.Access = Access;
        }
    }
}
