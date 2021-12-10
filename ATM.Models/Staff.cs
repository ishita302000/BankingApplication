﻿
using ATM.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Models
{
  public  class Staff // use one parent class for account holder and staff as they have multiple common properties
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

     //   public Dictionary<string, string> stafflogin;
        public Bank Bank { get; set; }
        public string BankId { get; set; }
        public Staff()
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
