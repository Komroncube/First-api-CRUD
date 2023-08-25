using Microsoft.EntityFrameworkCore;
using Service.Dtos.StaffsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _dbContext;

        public StaffRepository(AppDbContext appDbContext) 
        {
            this._dbContext = appDbContext;
        }
        
        public async Task AddEmployeeToStaffAsync(Guid staffId, List<Guid> employeeId)
        {
            var staff = await _dbContext.Staffs.Include(x=>x.Employees).FirstOrDefaultAsync(s => s.Id == staffId);

            if (staff is not null)
            {
                foreach (Guid i in employeeId)
                {
                    var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == i);
                    if(employee is not null)
                    {
                        staff.Employees.Add(employee);

                    }

                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateStaffAsync(CreateStaffDto createStaffDto)
        {
            var staff = new Staff()
            {
                Id = Guid.NewGuid(),
                Name = createStaffDto.Name,
            };
            await _dbContext.Staffs.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(Guid staffId)
        {
            var staff= await _dbContext.Staffs.FirstOrDefaultAsync(x=> x.Id == staffId);
            if (staff != null)
            {
                _dbContext.Staffs.Remove(staff);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _dbContext.Staffs.ToListAsync();
        }

        

        public async Task<List<Employee>> GetEmployeeByStaffIdAsync(Guid staffId)
        {
            var staff = await _dbContext.Staffs.Include(e => e.Employees)
                .FirstOrDefaultAsync(s => s.Id == staffId);
            if (staff is not null)
                return staff.Employees.ToList();
            return null;
        }

        public async Task<Staff> GetStaffByIdAsync(Guid staffId)
        {
            return await _dbContext.Staffs.FirstOrDefaultAsync(x => x.Id == staffId);
        }

        public async Task UpdateStaffAsync(Guid staffId, CreateStaffDto updateStaffDto)
        {
            var entity = await _dbContext.Staffs.FirstOrDefaultAsync(x => x.Id == staffId);
            if (entity != null)
            {
                entity.Name = updateStaffDto.Name;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
