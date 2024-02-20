﻿using Microsoft.AspNetCore.Mvc;
using CRUDApplicationAPI.Models;
using CRUDApplicationAPI.Services.Employee;

namespace CRUDApplicationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetEmployee/{Id?}")]
        public IActionResult GetEmployee(int? Id)
        {
            return Ok(_employeeRepository.GetEmployees(Id));
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] ManageEmployeeModel employee)
        {
            if (_employeeRepository.AddEmployee(employee) >= 1)
            {
                return Ok("The employee was created successfully.");
            }
            return BadRequest("Employee creation was unsuccessful.");
        }

        [HttpPut("UpdateEmployee/{Id}")]
        public IActionResult UpdateEmployee([FromBody] ManageEmployeeModel employee, [FromRoute] int Id)
        {
            if (_employeeRepository.UpdateEmployee(employee, Id) >= 1)
            {
                return Ok("The employee was updated successfully.");
            }
            return BadRequest("The employee update was unsuccessful.");
        }

        [HttpDelete("DeleteEmployee/{Id}")]
        public IActionResult DeleteEmployee(int Id)
        {
            if (_employeeRepository.DeleteEmployee(Id) >= 1)
            {
                return Ok("The employee was deleted successfully.");
            }
            return BadRequest("The employee deletion was unsuccessful.");
        }
    }
}
