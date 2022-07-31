using Koon.Models.Employees;
using Koon.Models.Leave;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koon.DAL
{
    public class KoonDBContext : DbContext
    {
        public KoonDBContext(DbContextOptions<KoonDBContext> options) : base(options)
        {

        }
        public DbSet<EmployeeState> States { get; set; }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<EmployeeDepartment> Departments { get; set; }
        public DbSet<EmployeeCity> Cities { get; set; }
        public DbSet<ApplyLeave> LeaveApplications { get; set; }
    }
}
