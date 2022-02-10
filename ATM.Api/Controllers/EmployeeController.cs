using ATM.Api.Models;
using ATM.Models;
using ATM.Models.Exceptions;
using ATM.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using ATM.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ATM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ICommanServices _accountService;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDbServices _dbservice;

        public EmployeeController(ICustomerServices accountService, ICommanServices commanServices, IMapper mapper, ILogger<EmployeeController> logger , IDbServices dbServices)
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
        
     

    }
}