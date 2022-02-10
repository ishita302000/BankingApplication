using ATM.Api.Models;
using ATM.Models;
using ATM.Models.Exceptions;
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
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController:Controller
    {
        private readonly ICommanServices _accountService;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ILogger<CurrencyController> _logger;
        private readonly IDbServices _dbservice;

        public CurrencyController(ICustomerServices accountService, ICommanServices commanServices, IMapper mapper, ILogger<CurrencyController> logger, IDbServices dbServices)
        {
            _customerServices = accountService;
            _accountService = commanServices;
            _mapper = mapper;
            _logger = logger;
            _dbservice = dbServices;
        }


        [HttpGet("{bankId}/{currencyName}")]
        public IActionResult GetCurrency(string bankId, string currencyName)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: "Fetching a Currency by name");
                return Ok(_dbservice.GetCurrencyByName(bankId, currencyName));
            }
            catch (CurrencyDoesNotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCurrency(Currency currency)
        {
            _dbservice.AddCurrency(currency);
            _logger.Log(LogLevel.Information, message: "Currrency Created Successfully");
            return Created($"{Request.Path}/{currency.Code}", currency);
        }

        [HttpPut("{bankId}/{currencyName}")]
        public IActionResult UpdateCurrency(string bankId, string currencyName, Currency updatedCurrency)
        {
            try
            {
                _dbservice.UpdateCurrency(updatedCurrency, bankId);
                _logger.Log(LogLevel.Information, message: "Currency Updated Successfully");
                return Ok(_dbservice.GetCurrencyByName(bankId, currencyName));
            }
            catch (CurrencyDoesNotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }



        [HttpPost("{bankId}/iscurrencynameexists")]
        public IActionResult IsCurrencyNameExists(string bankId, CurrencyNameDTO currencyName)
        {
            try
            {
                _dbservice.CheckCurrencyExistance(bankId, currencyName.CurrencyName);
                return Ok(new { CurrencyNameExists = true });
            }
            catch (CurrencyDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}