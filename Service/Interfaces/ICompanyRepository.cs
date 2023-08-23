namespace Service.Interfaces
{
    public interface ICompanyRepository
    {
        public Task CreateCompanyAsync(CreateCompanyDto createCompanyDto);
        public Task UpdateCompanyAsync(Guid id, CreateCompanyDto updateCompanyDto);
        public Task DeleteCompanyAsync(Guid companyId);
        public Task<ResultCompanyDto> GetCompanyByIdAsync(Guid id);
        public Task<List<ResultCompanyDto>> GetAllCompaniesAsync();
    }
}
