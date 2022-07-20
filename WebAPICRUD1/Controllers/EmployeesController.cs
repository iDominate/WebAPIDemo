using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICRUD1.Models;
using WebAPICRUD1.Respos;

namespace WebAPICRUD1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeesController(IEmployeeRepo repo)
        {
            employeeRepo = repo;    
        }
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            return Ok(employeeRepo.GetAllEmplyees());
        }
        [HttpGet("{id}")]
        public ActionResult GetEmployeeWithId(Guid id)
        {
            var employee = employeeRepo.GetEmployeeById(id);
            if(employee != null)
            {
                return Ok(employeeRepo.GetEmployeeById(id));
            }

            return NotFound();
            
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            employeeRepo.AddEmployee(employee);
            
            return Ok(employee);
        }

        [HttpDelete]
        public ActionResult DeleteEmployee(Guid id)
        {
            Employee employee = employeeRepo.GetEmployeeById(id);
            employeeRepo.DeleteEmployee(employee);
            return Ok();
        }

        [HttpPatch]
        public ActionResult UpdateEmployee(Employee employee)
        {
            
            return Ok(employeeRepo.EditEmployee(employee));
        }

        


    }
}
