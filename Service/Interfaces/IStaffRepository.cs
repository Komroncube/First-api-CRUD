using Service.Dtos.StaffsDto;

namespace Service.Interfaces
{
    public interface IStaffRepository
    {
        public Task CreateStaffAsync(CreateStaffDto createStaffDto);
        public Task<Staff> GetStaffByIdAsync(Guid staffId);
        public Task DeleteStaffAsync(Guid staffId);
        public Task UpdateStaffAsync(Guid staffId, CreateStaffDto updateStaffDto);
        public Task<List<Staff>> GetAllStaffAsync();
        public Task<List<Employee>> GetEmployeeByStaffIdAsync(Guid staffId);
        public Task AddEmployeeToStaffAsync(Guid staffId, List<Guid> employeesId);
    }
}
