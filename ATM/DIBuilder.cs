using System;
using ATM.Services;
using ATM.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.CLI
{
    public static class DIBuilder
    {
        public static IServiceProvider Build()
        {
            ServiceCollection services = new ServiceCollection();

            IMapper mapper = new MapperConfiguration(mc => {
                mc.AddProfile(new MapperProfile());
            }).CreateMapper();

            services
                .AddSingleton(mapper)
                .AddSingleton<ICommanServices, CommanServices>()
                .AddSingleton<ICustomerServices, CustomerServices>()
                .AddSingleton<IDbServices, DbServices>()
                .AddDbContext<BankContext>(options => options.UseSqlServer(connectionString: @"Data Source = LAPTOP-83O4PRPJ\MSSQLSERVER01; Initial Catalog = Banking_Application; Integrated Security = True"));
                
                
            return services.BuildServiceProvider();
        }
    }
}
