using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public enum PartType
    {
        Processor,
        Motherboard,
        RAM,
        Graphics_card,
        Hard_drive,
        Case,
        Power_supply,
        Operating_system,
        Mouse,
        Keyboard,
        Monitor,
        Desktop_PC,
        Gaming_PC
    }
    public class Part
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public PartType PartType { get; set; }
        public int PartPrice { get; set; }

        public ICollection<RepairOrder> RepairOrders { get; set; }

    }
}
