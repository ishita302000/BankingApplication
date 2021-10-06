using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class Input
    {
        public  static string getmessage()
        {
            Console.WriteLine("Please enter your input ");
            return Console.ReadLine();
        }
        public static double getMessage()
        {
            Console.WriteLine("Please enter your amount ");
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}
