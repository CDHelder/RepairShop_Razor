using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }    // Vervangen / weghalen

        public ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
