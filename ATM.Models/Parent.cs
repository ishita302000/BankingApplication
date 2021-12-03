﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
    public class Parent
    {
        public string Name { get; set; }
        public string Password
        {
            get; set;
        }
        public string Id { get; set; }
        private DateTime dateTime { get; set; }
        public Parent()
        {
            dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();

            Id = Name.Substring(0, 3);
            Id += date;
        }
    }
}
