using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class CreateCompanyDto
    {
        public CreateCompanyDto() { }
        /// <summary>
        /// maps Company class to CreateCompanyDto
        /// </summary>
        /// <param name="company"></param>
        public CreateCompanyDto(Company company)
        {
            Name=company.Name;
            Address=company.Address;
            Phone=company.Phone;
            Email=company.Email;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
