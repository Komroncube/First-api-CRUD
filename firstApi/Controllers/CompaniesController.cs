using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
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
        public async Task<IActionResult> UpdateCompanyAsync([FromForm] CreateCompanyDto updateCompany)
        {
            await _companyRepository.UpdateCompanyAsync(updateCompany);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAsync(Guid id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
            return Ok("Deleted");
        }
        [HttpGet("{id}")]
        public async Task<CreateCompanyDto?> GetCompanyById(Guid id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }
        [HttpGet]
        public async Task<List<CreateCompanyDto>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanysAsync();
        }
    }
}
