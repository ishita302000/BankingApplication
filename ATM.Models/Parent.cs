using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Parent
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Key]
        [Required]
        [StringLength(10)]
        public string Password
        {
            get; set;
        }

        [Key]
        [Required]
        [StringLength(50)]
        public string Id { get; set; }
        [Key]
        [Required]
        private DateTime dateTime { get; set; }
        public Parent()
        {
            dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();
            Id = "";
            for (int i = 0; i < 3; i++) Id += this.Name[i];
            Id += date;
        }
    }
}
