using ATM.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICommanServices _accountService;
        private readonly IDbServices _dbservice;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;
         public CustomerController(ICommanServices commanServices, IDbServices DbService, IMapper mapper, ILogger<CustomerController> logger)
        {
            _accountService = commanServices;
            _dbservice = DbService;
            _mapper = mapper;
            _logger = logger;
        }
    }
}