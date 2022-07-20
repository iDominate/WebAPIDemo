using WebAPICRUD1.Models;

namespace WebAPICRUD1.Respos
{
    public class SqlEmployeeData : IEmployeeRepo
    {
        private ApplicationDbContext _context;
        public SqlEmployeeData(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public Employee? EditEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                _context.SaveChanges();
                return existingEmployee;

            }

            return null;
        }

        public List<Employee> GetAllEmplyees()
        {
           return  _context.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
          return  _context.Employees.Find(id)!;
        }
    }
}
