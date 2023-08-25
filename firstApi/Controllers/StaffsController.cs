using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Dtos.StaffsDto;
using Service.Interfaces;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstApi.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;
        public StaffsController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            return await _staffRepository.GetAllStaffAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<string> GetAllEmployeesByStaffIdAsync(Guid id)
        {
            var result =  _staffRepository.GetEmployeeByStaffIdAsync(id).Result;
            string json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromForm] CreateStaffDto createStaffDto)
        {
            await _staffRepository.CreateStaffAsync(createStaffDto);
            return Ok("Created");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AddEmployeesToStaff(Guid id, List<Guid> employeeIds) 
        {
            await _staffRepository.AddEmployeeToStaffAsync(id, employeeIds);
            return Ok("Added");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffById(Guid id, [FromBody] CreateStaffDto createStaffDto)
        {
            await _staffRepository.UpdateStaffAsync(id, createStaffDto);
            return Ok("Update");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAsync(Guid id)
        {
            await _staffRepository.DeleteStaffAsync(id);
            return Ok("deleted");
        }
    }
}
