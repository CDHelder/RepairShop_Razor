using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepairShop_Razor.Data;
using RepairShop_Razor.Models;

namespace RepairShop_Razor.Data
{
    public class DbInitializer
    {
        public static void Initialize(RepairShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer{FirstMidName="Carson",LastName="Alexander"},
                new Customer{FirstMidName="Meredith",LastName="Alonso"},
                new Customer{FirstMidName="Arturo",LastName="Anand"},
                new Customer{FirstMidName="Gytis",LastName="Barzdukas"}
                
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{EmployeeID=1050,Name="Spiderman",Credits=3},
                new Employee{EmployeeID=4022,Name="Superman",Credits=3},
                new Employee{EmployeeID=4041,Name="Batman",Credits=3},
                new Employee{EmployeeID=1045,Name="DrPepper",Credits=4},
                new Employee{EmployeeID=3141,Name="Frans",Credits=4}
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();

            var repairOrders = new RepairOrder[]
            {
                new RepairOrder{CustomerID=1,EmployeeID=1050,Status=Status.Done},
                new RepairOrder{CustomerID=1,EmployeeID=4022,Status=Status.Done},
                new RepairOrder{CustomerID=1,EmployeeID=4041,Status=Status.Under_repair},
                new RepairOrder{CustomerID=2,EmployeeID=1045,Status=Status.On_hold},
                new RepairOrder{CustomerID=2,EmployeeID=3141,Status=Status.Waiting_for_parts},
                new RepairOrder{CustomerID=2,EmployeeID=2021,Status=Status.Under_repair},
            };

            context.RepairOrders.AddRange(repairOrders);
            context.SaveChanges();
        }
    }
}