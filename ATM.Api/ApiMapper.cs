using ATM.Api.Models;
using AutoMapper;
using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ATM.Api
{
    public class ApiMapper :Profile
    { 
        public ApiMapper()
        {
            
            CreateMap<Bank, BankDTO>();
            CreateMap<AccountCreated, Customer>().ForMember(dest => dest.Password, act => act.Ignore());
            CreateMap<Customer,AccountCreated>();
            CreateMap<EmployeeCreateDTO, Employee>().ForMember(dest => dest.Password, act => act.Ignore());
            CreateMap<Employee,EmployeeCreateDTO>();
            CreateMap<EmployeeActionCreateDTO, Employee>();
            CreateMap<Employee,EmployeeActionCreateDTO>();
            CreateMap< TransactionCreateDTO, Transaction>();
            CreateMap<Transaction,TransactionCreateDTO>();
        }
    }
}