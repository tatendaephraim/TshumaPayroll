using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TshumaPayroll.Data;
using TshumaPayroll.Models;

namespace TshumaPayroll.Pages.Employees
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

        public PaginatedList<Employee> Employees { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
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
            IQueryable<Employee> employeeIQ = from p in _context.Employees select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                employeeIQ = employeeIQ.Where(p => p.LastName.Contains(searchString) || p.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employeeIQ = employeeIQ.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    employeeIQ = employeeIQ.OrderByDescending(p => p.DateBirth);
                    break;
                case "date_desc":
                    employeeIQ = employeeIQ.OrderByDescending(p => p.DateBirth);
                    break;

                default:
                    employeeIQ = employeeIQ.OrderBy(p => p.LastName);
                    break;
            }
            int pageSize = 10;

            Employees = await PaginatedList<Employee>.CreateAsync(
                employeeIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}