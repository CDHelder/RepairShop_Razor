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

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(255)]
        public string FirstMidName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailAdress")]
        public string Emailadress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public int PhoneNumber { get; set; }

        public ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
