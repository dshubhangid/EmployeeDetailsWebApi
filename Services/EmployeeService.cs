using AutoMapper;
using EmployeeDetailsWebApi.Dtos;
using EmployeeDetailsWebApi.Models;
using EmployeeDetailsWebApi.Repositories.Interfaces;
using EmployeeDetailsWebApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsWebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public bool CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            
            Employee employee = _mapper.Map<Employee>(employeeCreateDto);
            _employeeRepository.CreateEmployee(employee);

            return (_employeeRepository.SaveChanges());
        }

        public IEnumerable<EmployeeReadDto> GetAllEmployees()
        {
           var employees = _employeeRepository.GetAllEmployees();
            if (employees == null || (employees.Count() == 0))
            {
                return null;
            }
           return _mapper.Map<IEnumerable<EmployeeReadDto>>(employees);          
        }

        public EmployeeReadDto GetEmployeeById(int id)
        {    
            var employee = _employeeRepository.GetEmployeeById(id);
            if(employee != null)
            {
                return  _mapper.Map<EmployeeReadDto>(employee);               
            }
            return null;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(int id,EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeModelFromRepo = _employeeRepository.GetEmployeeById(id);
            if (employeeModelFromRepo != null)
            {
                _mapper.Map(employeeUpdateDto, employeeModelFromRepo);
                _employeeRepository.UpdateEmployee(employeeModelFromRepo);
                _employeeRepository.SaveChanges();
            }
        }

        public bool DeleteEmployee(int id)
        {
            var employeeModelFromRepo = _employeeRepository.GetEmployeeById(id);
            if (employeeModelFromRepo != null)
            {
                _employeeRepository.DeleteEmployee(employeeModelFromRepo);
                _employeeRepository.SaveChanges();
                return true;
            }
            return false;
        }
        //public IEnumerable<Employee> GetAllEmployees()
        //{
        //    throw new NotImplementedException();
        //}

        //public EmployeeReadDto GetEmployeeById(int id)
        //{
        //    //var commandItem = _employeeService.GetEmployeeById(id);
        //    //if (commandItem != null)
        //    //{       
        //    //    return Ok(_mapper.Map<EmployeeReadDto>(commandItem));
        //    //}
        //    return NotFound();
        //    Employee employee = _employeeRepository.GetEmployeeById(id);

        //    return employee;
        //}

        //public bool SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateEmployee(Employee employee)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
