﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepairShop_Razor.Data;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Pages.Parts
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
            ViewData["PartType"] = new SelectList(Enum.GetValues<PartType>());
            return Page();
        }

        [BindProperty]
        public Part Part { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parts.Add(Part);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
