using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public enum Status
    {
        On_hold,
        Under_repair,
        Waiting_for_parts,
        Done
    }

    public class RepairOrder
    {
        public int RepairOrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int PartID { get; set; }
        public Status? Status { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Part Part { get; set; }

    }
}