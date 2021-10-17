using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.CLI
{
    class InputTakenFromUser
    {
        public  static int getmsg()
        {
            Console.WriteLine("Please enter your id ");
            return Convert.ToInt32(Console.ReadLine());
      }
     
        public static int getMessage()
        {
            Console.WriteLine("Please enter your amount ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
