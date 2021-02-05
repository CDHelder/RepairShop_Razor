using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShop_Razor.Data;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Pages.RepairOrders
{
    public class CreateModel : PageModel
    {
        private readonly RepairShop_Razor.Data.RepairShopContext _context;

        public CreateModel(RepairShop_Razor.Data.RepairShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "FirstMidName");
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            ViewData["PartID"] = new SelectList(_context.Parts, "PartID", "PartName");
            ViewData["Statussen"] = new SelectList(Enum.GetValues<Status>());
            ViewData["BeginDates"] = new SelectList(_context.RepairOrders, "RepairOrderID", "BeginDate");
            ViewData["EndDates"] = new SelectList(_context.RepairOrders, "RepairOrderID", "EndDate");
            ViewData["HoursWorked"] = new SelectList(_context.RepairOrders, "RepairOrderID", "HoursWorked");
            return Page();
        }

        [BindProperty]
        public RepairOrder RepairOrder { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RepairOrders.Add(RepairOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
