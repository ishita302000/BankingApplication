using System;
using System.Collections.Generic;
using System.Linq;
namespace ATM.Services
{
    public static class IDGenService
    {
    
        public static  string GenId(this string Name)
        {
            string Id;
            Id = Name.Substring(0, 3).ToUpper() + GetDateStr();
            return Id;
        }
        public static string GenTransactionId(this string bankId, string accId)
        {
            string TXNId;
            TXNId = "TXN" + bankId + accId + GetDateStr();
            return TXNId;
        }

        private static string GetDateStr()
        {
            DateTime date = DateTime.Now;
            string dateStr = date.ToString().Replace("-", string.Empty).Replace(" ", string.Empty).Replace(":", string.Empty);
            return dateStr;
        }
    }
}
