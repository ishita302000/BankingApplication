using ATM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATM.Services.DbModels
{
    public class DbBankModel
    {
        public string BankName { get; set; }
        [Key]
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
      
        public virtual IList<DbCurrencyModel> Currencies { get; set; }
        public virtual IList<DbEmployeeModel> StaffAccounts { get; set; }
        public virtual IList<DbTransactionModel> Transactions { get; set; }
        public virtual IList<DbCustomerModel> CustomerAccounts { get; set; }

        public double RTGSsameBank { get; set; } = 0;
        public double RTGSdifferentBank { get; set; } = .02;
        public double IMPSsameBank { get; set; } = 0.5;
        public double IMPSdifferentBank { get; set; } = .06;
        const string DefaultCurrency = "INR";
        public string Countrycode = DefaultCurrency;
    }
}
