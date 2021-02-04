using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string FirstMidName { get; set; }

        public ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
