using Domain.Entities;
using Mapster;
using MapsterMapper;

namespace Service.Services.Mapping
{
    public static class MappingService
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
        public static ResultEmployeeDto MapResultEmployee(this Employee employee)
        {
            var result = new ResultEmployeeDto()
            {


            };
            return result;
        }

    }
    /*[Mapper]
    public partial class Mapperly
    {
        public partial ResultCompanyDto Map(Company copmany);
    }*/
    /*[Mapper]
    public partial class CarMapper
    {
        public partial CarDto CarToCarDto(Car car);
    }

    // Mapper usage
    var mapper = new CarMapper();
    var car = new Car { NumberOfSeats = 10, ... };
    var dto = mapper.CarToCarDto(car);
    dto.NumberOfSeats.Should().Be(10);*/
}
