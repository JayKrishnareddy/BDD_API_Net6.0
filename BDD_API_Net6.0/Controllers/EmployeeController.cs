using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BDD_API_Net6._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       public List<Employee> employees = new();
        public EmployeeController()
        {
            employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Jay Krishna Reddy", Age = 26 },
                new Employee { Id = 2, Name = "Tom", Age = 36 },
                new Employee { Id = 3, Name = "Micheal", Age = 46 },
                new Employee { Id = 4, Name = "Henrik", Age = 28 },
                new Employee { Id = 5, Name = "Stefan", Age = 56 },
            };
        }
        // GET: api/<EmployeeController>
        [HttpGet(nameof(GetEmployeeList))]
        public List<Employee> GetEmployeeList()
        {
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(c => c.Id.Equals(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public List<Employee> Post([FromBody] Employee employee)
        {
            employees.Add(new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age
            });
            return employees;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }        
    }
}
