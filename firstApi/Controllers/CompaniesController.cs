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
    }
}
