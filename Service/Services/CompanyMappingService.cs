namespace Service.Services
{
    public static class CompanyMappingService
    {
        public static ResultCompanyDto MapResultCompany(this Company company)
        {
            var result = new ResultCompanyDto()
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Email = company.Email,
                Phone = company.Phone,
                Employees = company.Employees,
            };
            return result;
        }
        
    }
}
