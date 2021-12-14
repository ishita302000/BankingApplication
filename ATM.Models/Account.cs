using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Account 
    {
        [Required]
        public string Name
        {
            get; set;
          }
        [Required]
        public string Password { get; set;
        }
        [Key][Required]
        public string Id
        {
            get; set;
         }
        [Required]
        public DateTime dateTime
        {
            get; set;
        }
        [Required]
        public double currentbalance { get; set; } = 1000;
        [Required]
        public string BankId
        {
            get; set;
        }
    //    public virtual IList<Transaction> Transactions { get; set; }
        public Bank Bank { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public Account()
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
