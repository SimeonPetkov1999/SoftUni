using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Console.WriteLine(RemoveTown(new SoftUniContext()));
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
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department.Name,
                    Salary = e.Salary
                })
                .Where(e => e.Department == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();


            var employees = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();


            var sb = new StringBuilder();
            foreach (var addressText in employees)
            {
                sb.AppendLine(addressText);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(x => new
                    {
                        ProjectName = x.Project.Name,
                        StartDate = x.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndData = x.Project.EndDate == null ? "not finished" : x.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"),
                    }).ToList()
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndData}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    Employees = a.Employees.Count
                })
                .OrderByDescending(a => a.Employees)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10);

            var sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Employees} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                })
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.DepartmentName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var dept in departments)
            {
                sb.AppendLine($"{dept.DepartmentName} - {dept.ManagerFirstName} {dept.ManagerLastName}");

                foreach (var employee in dept.Employees
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList())
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                 .Where(x => x.FirstName.StartsWith("Sa"))
                 .Select(x => new Employee
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     JobTitle = x.JobTitle,
                     Salary = x.Salary
                 })
                 .OrderBy(x => x.FirstName)
                 .ThenBy(x => x.LastName)
                 .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);

            var employeeProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var item in employeeProjects)
            {
                context.EmployeesProjects.Remove(item);
            }
            context.SaveChanges();

            context.Projects.Remove(project);
            context.SaveChanges();

            var sb = new StringBuilder();
            var projects = context.Projects.Take(10);
            foreach (var item in projects)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            context.Employees
                       .Where(e => e.Address.Town.Name == "Seattle")
                       .ToList()
                       .ForEach(e => e.AddressId = null);

            var count = context.Addresses
                   .Where(a => a.Town.Name == "Seattle")
                   .Count();

            context.Addresses
                   .Where(a => a.Town.Name == "Seattle")
                   .ToList()
                   .ForEach(a => context.Addresses.Remove(a));

            var toRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            context.Towns.Remove(toRemove);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";

        }
    }
}
