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
                new Customer{Name="Carson"},
                new Customer{Name="Meredith"},
                new Customer{Name="Arturo"},
                new Customer{Name="Gytis"}
                
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{EmployeeID=1050,Name="Spiderman"},
                new Employee{EmployeeID=4022,Name="Superman"},
                new Employee{EmployeeID=4041,Name="Batman"},
                new Employee{EmployeeID=1045,Name="DrPepper"},
                new Employee{EmployeeID=3141,Name="Frans"}
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