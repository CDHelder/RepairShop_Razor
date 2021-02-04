using System;
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
    public class IndexModel : PageModel
    {
        private readonly RepairShop_Razor.Data.RepairShopContext _context;

        public IndexModel(RepairShop_Razor.Data.RepairShopContext context)
        {
            _context = context;
        }

        public IList<RepairOrder> RepairOrder { get;set; }

        public async Task OnGetAsync()
        {
            RepairOrder = await _context.RepairOrders
                .Include(r => r.Customer)
                .Include(r => r.Employee).ToListAsync();
        }
    }
}
