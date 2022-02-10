using ATM.Api.Models;
using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services;
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
    public class BankController : Controller
    {

        private readonly ICommanServices _accountService;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ILogger<BankController> _logger;
        private readonly IDbServices _dbservice;
        public BankController(ICustomerServices accountService, ICommanServices commanServices, IMapper mapper, ILogger<BankController> logger, IDbServices dbServices)
        {
            _customerServices = accountService;
            _accountService = commanServices;
            _mapper = mapper;
            _logger = logger;
            _dbservice = dbServices;
        }
        [HttpPost]
        public IActionResult CreateBank(Bank bank)
        {
            Bank newBank = new Bank
            {
                BankName = bank.BankName,
                Id = bank.BankName.GenId()
            };
            _dbservice.AddBank(newBank);
            _logger.Log(LogLevel.Information, message: "Created a Bank");
            return Created($"{Request.Path}/{newBank.Id}", _mapper.Map<BankDTO>(newBank));
        }

        [HttpPut("{bankId}")]
        public IActionResult UpdateBank(string bankId, Bank updatedBank)
        {
            try
            {
                _dbservice.UpdateBank(updatedBank);
                _logger.Log(LogLevel.Information, message: "Bank Updated Sucessfully");
                return Ok(_dbservice.GetBankById(bankId));
            }
            catch (BankDoesnotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{bankId}")]
        public IActionResult DeleteBank(string bankId)
        {
            try
            {
                _dbservice.DeleteBank(bankId);
                _logger.Log(LogLevel.Information, message: "Bank Deleted Sucessfully");
                return Ok("Bank Deleted Sucessfully");
            }
            catch (BankDoesnotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost("isbanknameexists")]
        public IActionResult IsBankNameExists(BankNameDTO Bankid)
        {
            try
            {
                _dbservice.CheckBankExistance(Bankid.Bankid);
                return Ok(new { BankNameExists = true });
            }
            catch
            {
                return Ok(new { BankNameExists = false });
            }

        }
    }
}