namespace Service.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task CreateEmployeeAsync(CreateEmployeeDto entity);
        public Task DeleteEmployeeAsync(Guid id);
        public Task<List<ResultEmployeeDto>> GetAllEmployeesAsync();
        public Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id);
        public Task UpdateEmployeeAsync(Guid id, CreateEmployeeDto entity);
    }
}
