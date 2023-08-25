using Domain.Entities;
using Service.Services.Mapping;

namespace Service.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;
        
        public CompanyRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {
            if (company is CreateCompanyDto createCompanyDto)
            {
                var companyCreate = new Company()
                {
                    Address = createCompanyDto.Address,
                    Email = createCompanyDto.Email,
                    Phone = createCompanyDto.Phone,
                    Name = createCompanyDto.Name,
                    Id = Guid.NewGuid(),
                };

                await _dbContext.Companies.AddAsync(companyCreate);
                await _dbContext.SaveChangesAsync();
            }
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
 
        public async Task<List<ResultCompanyDto>> GetAllCompaniesAsync()
        {
            var entities = await _dbContext.Companies.ToListAsync();
            var companies = new List<ResultCompanyDto>();
            foreach(var company in entities)
            {
                var obj = company.MapResultCompany();
                companies.Add(obj);
            }
            return companies;
        }

        

        public async Task<ResultCompanyDto> GetCompanyByIdAsync(Guid id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            return company.MapResultCompany();
            //return map.Map(company);
        }


        public async Task UpdateCompanyAsync(Guid id, CreateCompanyDto company)
        {
            var entity = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.Name=company.Name;
                entity.Phone=company.Phone;
                entity.Email=company.Email;
                entity.Address=company.Address;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
