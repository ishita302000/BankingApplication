using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Models
{
   public class Currency
    {
        public static Dictionary<string, double> curr = new Dictionary<string, double>()
        {
            { "EUR", 85.71},
            { "INR", 1.00},
            { "USD", 73.89}
        };
    }
}
