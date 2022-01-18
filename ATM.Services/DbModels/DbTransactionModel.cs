using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
     public class DbTransactionModel
    {
        public string SrcAccount { get; set; }
        public string DepAccount { get; set; }
        public string Id { get; set; }
        public double Amount { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DbCustomerModel Customer { get; set; }

    }
}
