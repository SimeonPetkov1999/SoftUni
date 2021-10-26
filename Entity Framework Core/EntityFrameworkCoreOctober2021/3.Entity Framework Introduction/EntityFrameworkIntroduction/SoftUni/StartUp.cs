using Microsoft.EntityFrameworkCore;
using SoftUni.Models;
using SoftUni.Data;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            var result = AddNewAddressToEmployee(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTittle = x.JobTitle,
                    Salary = x.Salary
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTittle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new
                {
                    Name = x.FirstName,
                    Salary = x.Salary,
                })
                .OrderBy(x => x.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var item in employees)
            {
                result.AppendLine($"{item.Name} - {item.Salary:f2}");

            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) 
        {
            var employees = context
               .Employees
               .Where(x => x.Department.Name == "Research and Development")
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName,
                   DepartmentName = x.Department.Name,
                   Salary = x.Salary,
               })
               .OrderBy(x => x.Salary)
               .ThenByDescending(x=> x.FirstName)
               .ToList();

            var result = new StringBuilder();

            foreach (var item in employees)
            {
                result.AppendLine($"{item.FirstName} {item.LastName} from {item.DepartmentName} - ${item.Salary:f2}");

            }

            return result.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            var employee = context
                .Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            var address = new Address() { TownId = 4, AddressText = "Vitoshka 15" };

            employee.Address = address;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => x.Address.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in addresses)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }

    }
}
