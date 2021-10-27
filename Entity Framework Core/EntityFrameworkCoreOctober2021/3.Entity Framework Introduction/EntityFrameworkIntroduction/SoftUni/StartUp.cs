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
            var result = DeleteProjectById(context);
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
               .ThenByDescending(x => x.FirstName)
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

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.EmployeesProjects.Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(y => new
                    {
                        ProjectName = y.Project.Name,
                        StartDate = y.Project.StartDate,
                        EndDate = y.Project.EndDate == null ? "not finished" : y.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"),
                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - Manager: {item.ManagerFirstName} {item.ManagerLastName}");
                foreach (var project in item.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {project.EndDate}");
                }
            }

            return sb.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .Take(10)
                .Select(x => new
                {
                    x.AddressText,
                    x.Town.Name,
                    Count = x.Employees.Count()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in addresses)
            {
                sb.AppendLine($"{item.AddressText}, {item.Name} - {item.Count} employees");
            }

            return sb.ToString();

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.EmployeesProjects.Select(ep => ep.Project.Name)
                })
                .FirstOrDefault();

            var sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var item in employee.Projects.OrderBy(x => x))
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(x => x.Employees.Count > 5)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle,
                    })

                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var department in departments.OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.Employees.OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName))
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
                .OrderByDescending(x => x.StartDate)
                .Take(10);

            var sb = new StringBuilder();

            foreach (var project in projects.OrderBy(x=>x.Name))
            {
                sb.AppendLine(project.Name)
                    .AppendLine(project.Description)
                    .AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));             
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context) 
        {
            var employees = context
                .Employees
                .Where(x => x.Department.Name == "Engineering" ||
                x.Department.Name == "Tool Design" ||
                x.Department.Name == "Marketing" ||
                x.Department.Name == "Information Services")
                .OrderBy(x=>x.FirstName)
                .ThenBy(x=>x.LastName);

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();

            return sb.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context) 
        {
            var employees = context
                .Employees
                .Where(x => EF.Functions.Like(x.FirstName, "sa%"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            var sb = new StringBuilder();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }

            return sb.ToString();

        }

        public static string DeleteProjectById(SoftUniContext context) 
        {
            var projects = context
                .EmployeesProjects
                .Where(x => x.ProjectId == 2);
            var project = context.Projects.Find(2);

            context.EmployeesProjects.RemoveRange(projects);
            context.Projects.Remove(project);
            context.SaveChanges();

            var newProjects = context
                .Projects
                .Take(10)
                .Select(x => x.Name);

            var sb = new StringBuilder();

            foreach (var item in newProjects)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
            
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
