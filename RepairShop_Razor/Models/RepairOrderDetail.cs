using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public class RepairOrderDetail
    {
        public int RepairOrderID { get; set; }
        public int RepairOrderDetailId { get; set; }
        public int PartID { get; set; }
        public string PartName { get; set; }
        public int PartPrice { get; set; }
        public int Quantity { get; set; }

        //public RepairOrder RepairOrder { get; set; }
        public Part Part { get; set; }

    }
}
