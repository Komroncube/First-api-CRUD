using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
