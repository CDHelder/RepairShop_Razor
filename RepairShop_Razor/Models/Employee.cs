using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepairShop_Razor.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        public int Credits { get; set; }    // Vervangen / weghalen

        /*
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EmailAdress")]
        public string Emailadress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public int PhoneNumber { get; set; }

        [Display(Name ="Adress")]
        public string Adress { get; set; }

        Als deze aanstaat werkt RepairOrder en nog een andere pagina niet?!
        Maybe eerst alles afmaken want hij werkte niet toen ik pas de helft af had
        */

        public ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
