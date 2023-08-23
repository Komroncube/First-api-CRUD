using Domain.Entities;
using Service.Dtos;

namespace Service.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateCompanyAsync(CreateCompanyDto company);
        public Task DeleteCompanyAsync(Guid id);
        public Task<CreateCompanyDto?> GetCompanyByIdAsync(Guid id);
        public Task<List<CreateCompanyDto>> GetAllCompanysAsync();
        public Task UpdateCompanyAsync(CreateCompanyDto company);
    }
}
