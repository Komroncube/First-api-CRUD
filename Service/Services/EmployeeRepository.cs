using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task CreateEmployeeAsync(CreateCompanyDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultEmployeeDto>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultCompanyDto> GetEmployeeByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(Guid id, CreateCompanyDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
