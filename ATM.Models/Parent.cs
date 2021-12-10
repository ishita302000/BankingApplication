using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class Parent
    {
    
        [Required]
       public string Name { get; set; }
     /*   [Key]
        [Required]
        [StringLength(10)]*/
        public string Password
        {
            get; set;
        }
        [Key]
        [Required]
     
        public string Id { get; set; }
        //[Key]
        //[Required]
        public DateTime dateTime { get; set; }
        //     dateTime = DateTime.Now;
        //   string date = dateTime.ToShortDateString();
        public Parent()
        {
        }

            public Parent( string Name , string Password)
           {
               this.Name = Name;
               this.Password = Password;
               this.dateTime = DateTime.Now;
               string date = dateTime.ToShortDateString();
               this.Id = "";
               for (int i = 0; i < 3; i++) this.Id += this.Name[i];
               Id += date;
           }
    }
}
