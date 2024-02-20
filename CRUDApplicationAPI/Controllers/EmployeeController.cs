using Microsoft.AspNetCore.Mvc;
using CRUDApplicationAPI.Models;

namespace CRUDApplicationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetEmployee/{Id?}")]
        public IActionResult GetEmployee(int? Id)
        {
            return Ok();
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeModel employee)
        {
            return Ok();
        }

        [HttpPut("UpdateEmployee/{Id}")]
        public IActionResult UpdateEmployee([FromBody] EmployeeModel employee, [FromRoute] int Id)
        {
            return Ok();
        }

        [HttpDelete("DeleteEmployee/{Id}")]
        public IActionResult DeleteEmployee(int? Id)
        {
            return Ok();
        }
    }
}
