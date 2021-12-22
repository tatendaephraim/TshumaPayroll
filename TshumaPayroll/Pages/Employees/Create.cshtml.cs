using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TshumaPayroll.Data;
using TshumaPayroll.Models;

namespace TshumaPayroll.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly TshumaDbContext _context;

        public CreateModel(TshumaDbContext context)
        {
            _context = context;
        }
        public List<Salary> Salaries { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Salaries = await _context.Salaries
                .Where(i => i.EmployeeId == id)
                .ToListAsync();

            return Page();
        }



        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
