using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Services;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace EmployeeManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetAllEmployeeAsync()
        {
            return Ok(await _service.GetAllEmployeesAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployeeByIdAsync(int id)
        {
            return Ok(await _service.GetEmployeeByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> AddEmployeeAsync(EmployeeCreateViewModel employee)
        {
            return Ok(await _service.AddEmployeeAsync(employee));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> UpdateEmployeeAsync(int id, EmployeeUpdateViewModel employee)
        {
            return Ok(await _service.UpdateEmployeeAsync(id, employee));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return "Successfullly Deleted";
        }
    }
}
