using ATM.Api.Models;
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
    public class CommanController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICustomerServices _customerServices;
        private readonly IDbServices _dbServices;
        private readonly ILogger<CommanController> _logger;

        public CommanController(ICustomerServices accountService, IDbServices DbService, IMapper mapper, ILogger<CommanController> logger)
        {
            _customerServices = accountService;
            _dbServices = DbService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{accountId}")]
        public IActionResult GetAllTransactions(string accountId)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Fetching all transactions of account {accountId}");
                return Ok(_dbServices.GetTransactions(accountId));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetBanks()
        {
            try
            {
                _logger.Log(LogLevel.Information, message: "Fetching all the banks");
                return Ok(_mapper.Map<BankDTO[]>(_dbServices.GetAllBankNames()));
            }
            catch (BankDoesnotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{bankId}")]
        public IActionResult GetBank(string bankId)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Fetching the bank with the id {bankId}");
                return Ok(_mapper.Map<BankDTO>(_dbServices.GetBankById(bankId)));
            }
            catch (BankDoesnotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

    }
}