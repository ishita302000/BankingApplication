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
    public class DbController : Controller
    {
        private readonly ICommanServices _accountService;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ILogger<DbController> _logger;
        private readonly IDbServices _dbservice;

        public DbController(ICustomerServices accountService, ICommanServices commanServices, IMapper mapper, ILogger<DbController> logger , IDbServices dbServices)
        {
            _customerServices = accountService;
            _accountService = commanServices;
            _mapper = mapper;
            _logger = logger;
            _dbservice = dbServices;
        }
        [HttpGet("id/{bankid}")]
        public IActionResult GetEmployeeById(string id , string bankid)
        {
            try
            {
                _logger.Log(LogLevel.Information, message: $"Fetching Employee by id {id}");
                return Ok(_dbservice.GetEmployeeById(id , bankid));
            }
            catch(EmployeeDoesNotExistException ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateDTO employee)
        {
            Employee newEmployee = _mapper.Map<Employee>(employee);
            newEmployee.EmployeeId = employee.Name.GenId();
            _dbservice.AddStaff(newEmployee);
            _logger.Log(LogLevel.Information, message: "Created New Employee");
            return Created($"{Request.Path}/id/{newEmployee.EmployeeId}", _mapper.Map<Employee>(newEmployee));
        }

        [HttpPut("id/{id}")]
        public IActionResult UpdateEmployee(string id, EmployeeCreateDTO employee)
        {
            Employee newEmployee = _mapper.Map<Employee>(employee);
           // string employeeId = _dbservice.GetStaffIdByname();
            try
            {
                
                _dbservice.UpdateEmployee( newEmployee);
                _logger.Log(LogLevel.Information, message: "Employee Updated Succesfully");
                return Ok(_dbservice.GetEmployeeById(id , newEmployee.EmployeeId));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }
        
        //////////////////////////Transaction
      

        [HttpPost]
        public IActionResult CreateTransaction(TransactionCreateDTO transaction)
        {
            Transaction newTransaction = _mapper.Map<Transaction>(transaction);
            newTransaction.Id = transaction.BankId.GenTransactionId(transaction.AccountId);
            _dbservice.AddTransaction(newTransaction);
            _logger.Log(LogLevel.Information, message: "New Transaction Created");
            return Created($"{Request.Path}/{transaction.AccountId}", newTransaction);
        }

        [HttpPost("revert/{id}")]
        public IActionResult RevertTransaction(string id)
        {
            try
            {
                _dbservice.revertTransaction(id);
                _logger.Log(LogLevel.Information, message: "Transaction reverted Successfully");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, message: ex.Message);
                return NotFound(ex.Message);
            }
        }
   ///Currency
        

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
                _dbservice.UpdateCurrency(updatedCurrency , bankId);
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
                return Ok( new{ CurrencyNameExists = _dbservice.CheckCurrencyExistance(bankId, currencyName.CurrencyName) });
            }
            catch (CurrencyDoesNotExistException ex)
            {
                return NotFound(ex.Message);
            }
        }
        //////bank
      

        [HttpPost]
        public IActionResult CreateBank(Bank bank)
        {
            Bank newBank = new Bank
            {
                BankName = bank.BankName,
                Id = bank.Name.GenId()
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
            return Ok(new { BankNameExists = _dbservice.CheckBankExistance(Bankid)});
        }

    }
}