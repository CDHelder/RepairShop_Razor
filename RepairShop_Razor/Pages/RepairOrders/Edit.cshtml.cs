using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepairShop_Razor.Data;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Pages.RepairOrders
{
    public class EditModel : PageModel
    {
        private readonly RepairShop_Razor.Data.RepairShopContext _context;

        public EditModel(RepairShop_Razor.Data.RepairShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RepairOrder RepairOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RepairOrder = await _context.RepairOrders
                .Include(r => r.Customer)
                .Include(r => r.Employee).FirstOrDefaultAsync(m => m.RepairOrderID == id);

            if (RepairOrder == null)
            {
                return NotFound();
            }
           ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
           ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RepairOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairOrderExists(RepairOrder.RepairOrderID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.RepairOrderID == id);
        }
    }
}
