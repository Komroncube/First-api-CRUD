namespace Service.Dtos.Companies
{
    public class ResultCompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
