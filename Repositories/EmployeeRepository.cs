using EmployeeDetailsWebApi.Models;
using EmployeeDetailsWebApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsWebApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _employeeDbContext.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeDbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeDbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public bool SaveChanges()
        {
            return (_employeeDbContext.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeDbContext.Update(employee);
        }

        //Delete Remaining
        public void DeleteEmployee(Employee employee)
        {
            _employeeDbContext.Remove(employee);
        }
    }
}
