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
            return Ok(_departmentRepository.GetDepartments(Id));
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment([FromBody] DepartmentModel department)
        {
            if(_departmentRepository.AddDepartment(department) >= 1)
            { 
                return Ok("The department was created successfully.");
            }
            return BadRequest("Department creation was unsuccessful.");
        }

        [HttpPut("UpdateDepartment/{Id}")]
        public IActionResult UpdateDepartment([FromBody] DepartmentModel department, [FromRoute] int Id)
        {
            if (_departmentRepository.UpdateDepartment(department, Id) >= 1)
            {
                return Ok("The department was updated successfully.");
            }
            return BadRequest("The department update was unsuccessful.");
        }

        [HttpDelete("DeleteDepartment/{Id}")]
        public IActionResult DeleteDepartment(int Id)
        {
            if (_departmentRepository.DeleteDepartment(Id) >= 1)
            {
                return Ok("The department was deleted successfully.");
            }
            return BadRequest("The department deletion was unsuccessful.");
        }
    }
}
