using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TshumaPayroll.Data;
using TshumaPayroll.Models;

namespace TshumaPayroll.Pages.Salaries
{
    public class IndexModel : PageModel
    {
        private readonly TshumaDbContext _context;

        public IndexModel(TshumaDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Salary> Salaries { get; set; }
        public Salary Salary { get; set; }
        public Employee Employee { get; set; } 
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, int? id)
        {
            Salary = new Salary();
            Employee = new Employee();

           
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            currentFilter = searchString;
            //Include Employee in the IQueryable to access the values in the related table
            IQueryable<Salary> employeeIQ = from p in _context.Salaries.Include(i=>i.Employee)
                                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                employeeIQ = employeeIQ.Where(p => nameof(p.SalaryMonth.GetNames).ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employeeIQ = employeeIQ.OrderByDescending(p => p.SalaryMonth);
                    break;
                default:
                    break;
            }
            int pageSize = 10;

            //Try application of Lazy Loading on the related data
            

            Salaries = await PaginatedList<Salary>.CreateAsync(
                employeeIQ
                .AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
