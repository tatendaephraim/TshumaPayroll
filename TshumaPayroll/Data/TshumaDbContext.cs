using Microsoft.EntityFrameworkCore;
using TshumaPayroll.Models;

namespace TshumaPayroll.Data
{
    public class TshumaDbContext:DbContext
    {
        public TshumaDbContext(DbContextOptions<TshumaDbContext> options)
            : base(options)
        {

        }
        //DBSETS FOR THE MODEL CLASSES AS REFLECTED IN THE DATABASE ON MODEL CREATING
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
