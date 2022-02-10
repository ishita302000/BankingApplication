using ATM.Api.Models;
using ATM.Services;
using ATM.Services.IServices;
using AutoMapper;
using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ATM.Api.Controllers
{
    public class TransactionController :Controller
    {
        private readonly ICommanServices _accountService;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionController> _logger;
        private readonly IDbServices _dbservice;

        public TransactionController(ICustomerServices accountService, ICommanServices commanServices, IMapper mapper, ILogger<TransactionController> logger, IDbServices dbServices)
        {
            _customerServices = accountService;
            _accountService = commanServices;
            _mapper = mapper;
            _logger = logger;
            _dbservice = dbServices;
        }

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

    }
}