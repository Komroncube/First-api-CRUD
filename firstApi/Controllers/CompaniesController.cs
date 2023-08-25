using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Companies;
using Service.Dtos.Employees;
using Service.Interfaces;

namespace firstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDto createCompanyDto)
        {
            await _companyRepository.CreateCompanyAsync(createCompanyDto);
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAsync([FromForm] Guid id, CreateCompanyDto updateCompany)
        {
            await _companyRepository.UpdateCompanyAsync(id, updateCompany);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAsync(Guid id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
            return Ok("Deleted");
        }
        [HttpGet("{id}")]
        public async Task<ResultCompanyDto> GetCompanyById(Guid id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }
        [HttpGet]
        public async Task<List<ResultCompanyDto>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }
    }
}
