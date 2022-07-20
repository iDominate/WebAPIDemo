using WebAPICRUD1.Models;

namespace WebAPICRUD1.Respos
{
    public interface IEmployeeRepo
    {
        List<Employee> GetAllEmplyees();
        Employee GetEmployeeById(Guid id);
        void AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee? EditEmployee(Employee employee);
    }
}
