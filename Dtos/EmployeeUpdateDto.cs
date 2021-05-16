using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetailsWebApi.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Organization { get; set; }
        public string Position { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }
    }
}
