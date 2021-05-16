using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDetailsWebApi.Dtos;
using EmployeeDetailsWebApi.Models;
using EmployeeDetailsWebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailsWebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
        {

            EmployeeReadDto employeeDto = _employeeService.GetEmployeeById(id);
            if (employeeDto != null)
            {
                return Ok(employeeDto);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(_employeeService.GetAllEmployees()));
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeCreateDto employeeCreatedDto)
        {
           if (employeeCreatedDto == null)
                return BadRequest();
           if( _employeeService.CreateEmployee(employeeCreatedDto))
           {
                return Ok();
           }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public ActionResult<EmployeeReadDto> UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            if (id == 0 || employeeUpdateDto == null)
            {
                return BadRequest();
            }
            _employeeService.UpdateEmployee(id, employeeUpdateDto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult<EmployeeReadDto> DeleteEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (_employeeService.DeleteEmployee(id))
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
