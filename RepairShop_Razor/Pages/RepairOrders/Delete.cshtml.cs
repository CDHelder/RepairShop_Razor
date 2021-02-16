﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RepairShop_Razor.Data;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Pages.RepairOrders
{
    public class DeleteModel : PageModel
    {
        private readonly RepairShop_Razor.Data.RepairShopContext _context;

        public DeleteModel(RepairShop_Razor.Data.RepairShopContext context)
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
                .Include(r => r.Employee)
                .Include(r => r.RepairOrderDetails).FirstOrDefaultAsync(m => m.RepairOrderID == id);

            if (RepairOrder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RepairOrder = await _context.RepairOrders.FindAsync(id);

            if (RepairOrder != null)
            {
                _context.RepairOrders.Remove(RepairOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
