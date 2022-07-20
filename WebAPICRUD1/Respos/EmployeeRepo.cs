using WebAPICRUD1.Models;

namespace WebAPICRUD1.Respos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private ApplicationDbContext context;
        public EmployeeRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        /*private List<Employee> _employee = new()
            {
                new Employee(){Id = Guid.NewGuid(), Name = "Ahmed"},
                new Employee(){Id = Guid.NewGuid(), Name = "Muhammed"},
                new Employee(){Id = Guid.NewGuid(), Name = "Ali"},

            };*/
        public void AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public Employee? EditEmployee(Employee employee)
        {
            Employee existingEmployee = context.Employees.Find(employee.Id)!;
            if(existingEmployee != null)
            {
                
                
                existingEmployee.Name = employee.Name;
                
                context.SaveChanges();

                return existingEmployee;
            }
            return null;
        }

        public List<Employee> GetAllEmplyees()
        {
            return context.Employees.ToList();
        }

        

        public Employee GetEmployeeById(Guid id)
        {
            return context.Employees.Where(e => e.Id == id).FirstOrDefault()!;
        }
    }
}
