using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [Display(Name = "Repair Status")]
        public Status? Status { get; set; }

        [Range(0,1000, ErrorMessage = "Please enter a value between 0 and 1000")]
        [Display(Name = "Hours Worked")]
        public int HoursWorked { get; set; }

        [Required(ErrorMessage = "Begin date is required")]
        [Display(Name = "Begin date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        public string Description { get; set; }


        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Part Part { get; set; }

    }
}