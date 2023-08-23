namespace Service.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateEmployeeAsync(CreateCompanyDto entity);
        public Task DeleteEmployeeAsync(Guid id);
        public Task<List<ResultEmployeeDto>> GetAllEmployeesAsync();
        public Task<ResultCompanyDto> GetEmployeeByIdAsync(Guid id);
        public Task UpdateEmployeeAsync(Guid id, CreateCompanyDto entity);
    }
}
