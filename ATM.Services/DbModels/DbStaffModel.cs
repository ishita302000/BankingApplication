using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
     public class DbStaffModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        [Key]
        [Required]
        public string Id;

        public Dictionary<string, string> stafflogin;
        public Bank Bank { get; set; }
        public string BankId { get; set; }
        public DbStaffModel()
        {
            DateTime currentDate = DateTime.Now;

            string date = currentDate.ToShortDateString();
            // set accountId
            Id = "";
            for (int i = 0; i < 3; i++) Id += this.Name[i];
            Id += date;
        }
    }
}
