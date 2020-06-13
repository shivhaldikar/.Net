using System;
using System.Linq;
using System.Collections.Generic;

namespace GroupByTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new Employee[]
            {
                new Employee{ Id = 1, Contact = "+253336626", Name = "Jason Right", Company = "Amazon"},
                new Employee{ Id = 1, Contact = "+253336626", Name = "Bill Gates", Company = "Microsoft"},
                new Employee{ Id = 1, Contact = "+253336626", Name = "Jim Carry", Company = "Amazon"},
                new Employee{ Id = 1, Contact = "+253336626", Name = "Jesica Jones", Company = "Microsoft" },
            };

            var employeesGroupBy = employees.GroupBy(employee => employee.Company);
            foreach (var employeeGroup in employeesGroupBy)
            {
                Console.WriteLine($"{employeeGroup.Key} = ");
                employeeGroup.ToList().ForEach(employee => Console.WriteLine($"\t\t{employee.ToString()}"));
            }

            Console.Read();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Company { get; set; }

        public override string ToString()
        {
            return string.Join(", ", GetType().GetProperties().Select(
                property => $"{property.Name}: {property.GetValue(this)}"));
        }
    }
}
