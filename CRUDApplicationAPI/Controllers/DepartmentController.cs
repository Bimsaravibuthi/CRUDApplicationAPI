using Microsoft.AspNetCore.Mvc;
using CRUDApplicationAPI.Models;
using CRUDApplicationAPI.Services.Department;

namespace CRUDApplicationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("GetDepartment/{Id?}")]
        public IActionResult GetDepartment(int? Id)
        {
            var result = _departmentRepository.GetDepartments();
            return Ok(result);
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment([FromBody] DepartmentModel department)
        {
            return Ok();
        }

        [HttpPut("UpdateDepartment/{Id}")]
        public IActionResult UpdateDepartment([FromBody] DepartmentModel department, [FromRoute] int Id)
        {
            return Ok();
        }

        [HttpDelete("DeleteDepartment/{Id}")]
        public IActionResult DeleteDepartment(int? Id)
        {
            return Ok();
        }
    }
}
