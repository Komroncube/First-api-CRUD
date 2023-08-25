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
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateEmployeeAsync(CreateEmployeeDto entity)
        {
            var employee = new Employee()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone,
                Email = entity.Email,
                Id=Guid.NewGuid(),
                CompanyId=entity.CompanyId,
            };
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var entity=await _dbContext.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            if (entity != null)
            {
                _dbContext.Employees.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeesAsync()
        {
            var result=await _dbContext.Employees.Join(_dbContext.Companies,
                x=>x.CompanyId,
                i=>i.Id,
                (x,i) => new ResultEmployeeDto()
                {
                    Id=x.Id,
                    FirstName =x.FirstName,
                    LastName =x.LastName,
                    Phone = x.Phone,
                    Email = x.Email,
                    CompanyName = i.Name,
                    CompanyAddress = i.Address,
                    CompanyPhone = i.Phone,
                    CompanyEmail = i.Email,
                }).ToListAsync();
            return result;
        }

        public async Task<ResultEmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var result = await _dbContext.Employees
                .Join(_dbContext.Companies,
                    employee => employee.CompanyId,
                    company => company.Id,
                    (employee, company) => new ResultEmployeeDto()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Phone = employee.Phone,
                        Email = employee.Email,
                        CompanyName = company.Name,
                        CompanyAddress = company.Address,
                        CompanyPhone = company.Phone,
                        CompanyEmail = company.Email,
                    })
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


        public async Task UpdateEmployeeAsync(Guid id, CreateEmployeeDto entity)
        {
            var obj =await _dbContext.Employees.FirstOrDefaultAsync(x=>x.Id == id);
            if (entity!=null)
            {
                obj.FirstName = entity.FirstName;
                obj.LastName = entity.LastName;
                obj.Phone = entity.Phone;
                obj.Email = entity.Email;
                obj.CompanyId = entity.CompanyId;
            }
        }

    }
}
