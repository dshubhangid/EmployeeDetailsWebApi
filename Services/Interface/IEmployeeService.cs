using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetailsWebApi.Dtos;
using EmployeeDetailsWebApi.Repositories.Interfaces;

namespace EmployeeDetailsWebApi.Services.Interface
{
    public interface IEmployeeService 
    {
        bool SaveChanges();
        IEnumerable<EmployeeReadDto> GetAllEmployees();
        EmployeeReadDto GetEmployeeById(int id);
        bool CreateEmployee(EmployeeCreateDto employee);
        void UpdateEmployee(int id, EmployeeUpdateDto employee);
         bool DeleteEmployee(int id);

    }
}
