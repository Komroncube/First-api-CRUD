using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Employees;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstApi.Controllers
{

    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<ResultEmployeeDto>> GetAll()
        {
            return await employeeRepository.GetAllEmployeesAsync();
            
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ResultEmployeeDto> GetEmployeeById(Guid id)
        {
            return await employeeRepository.GetEmployeeByIdAsync(id);
           
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto createEmployeeDto)
        {
            await employeeRepository.CreateEmployeeAsync(createEmployeeDto);
            return Ok("Created");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(Guid id, [FromForm] CreateEmployeeDto createEmployeeDto)
        {
            await employeeRepository.UpdateEmployeeAsync(id, createEmployeeDto);
            return Ok("Updated");
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(Guid id)
        {
            await employeeRepository.DeleteEmployeeAsync(id);
            return Ok("deleted");
        }
    }
}
