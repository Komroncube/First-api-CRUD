using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteCompanyAsync(Guid id)
        {
            var entity = await _dbContext.Companies.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Companies.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CreateCompanyDto>> GetAllCompanysAsync()
        {
            var companies = await _dbContext.Companies.ToArrayAsync();
            var companyDto = companies.Select(x => new CreateCompanyDto(x)).ToList();
            return companyDto;
        }

        public async Task<CreateCompanyDto?> GetCompanyByIdAsync(Guid id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company != null)
            {
                return new CreateCompanyDto(company);
            }
            return null;
        }

        public async Task UpdateCompanyAsync(CreateCompanyDto company)
        {
            var entity = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Email == company.Email);
            if (entity != null)
            {
                entity.Name=company.Name;
                entity.Phone=company.Phone;
                entity.Address=company.Address;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
