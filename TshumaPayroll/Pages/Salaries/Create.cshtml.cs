using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TshumaPayroll.Data;
using TshumaPayroll.Models;

namespace TshumaPayroll.Pages.Salaries
{
    public class CreateModel : PageModel
    {
        private readonly TshumaDbContext _context;

        public CreateModel(TshumaDbContext context)
        {
            _context = context;
        }
       
       
        [BindProperty]
        public Employee Employee { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
           

            Employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            
            return Page();
        }

        [BindProperty]
        public Salary Salary { get; set; }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //New Code
            Employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Salaries.Add(Salary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id });
        }
    }
}
