using Domain.Entities;
using Mapster;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this._dbContext = appDbContext;
        }
        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {
            var companycreate = new Company()
            {
                Address = company.Address,
                Email = company.Email,
                Phone = company.Phone,
                Name = company.Name,
                Id = Guid.NewGuid(),
            };


            await _dbContext.Companies.AddAsync(companycreate);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteCompanyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CreateCompanyDto>> GetAllCompanysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CreateCompanyDto> GetCompanyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(CreateCompanyDto company)
        {
            throw new NotImplementedException();
        }
    }
}
