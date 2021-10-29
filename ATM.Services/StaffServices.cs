using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ATM.Models;
using ATM.Models.Enums;

namespace ATM.Services
{
    class StaffServices
    {
        Staff staff;
        public Staff StaffPerson;
        StaffServices(string name , string password , StaffLoginType access )
        {
            StaffPerson = new Staff(name,password,access);
            access = StaffLoginType.StaffMember;
        }
    }

   
}
