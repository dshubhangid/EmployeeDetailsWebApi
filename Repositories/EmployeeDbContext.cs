using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDetailsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetailsWebApi.Repositories
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> opt) : base(opt)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
