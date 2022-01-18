using ATM.Models;
using ATM.Services.DbModels;
using AutoMapper;

namespace ATM.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, DbCustomerModel>();
            CreateMap<DbCustomerModel, Customer>();
            CreateMap<Bank, DbBankModel>();
            CreateMap<DbBankModel, Bank>();
            CreateMap<Employee, DbEmployeeModel>();
            CreateMap<DbEmployeeModel, Employee>();
            CreateMap<Currency, DbCurrencyModel>();
            CreateMap<DbCurrencyModel, Currency>();
            CreateMap<Transaction, DbTransactionModel>();
            CreateMap<DbTransactionModel, Transaction>();
           
        }
    }
}
