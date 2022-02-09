using ATM.Api;
using ATM.Services;
using ATM.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//configuring mapper
IMapper mapper = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
    mc.AddProfile(new ApiMapper());
}).CreateMapper();

builder.Services.AddDbContext<BankContext>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("value")))
    .AddSingleton(mapper)
    .AddScoped<ICommanServices, CommanServices>()
    .AddScoped<ICommanServices, CommanServices>()
    .AddScoped<IDbServices, DbServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
