namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var input = XmlConverter
                .Deserializer<ImportProjectsDto[]>(xmlString, "Projects", true);

            var sb = new StringBuilder();

            var projects = new List<Project>();

            foreach (var currentProject in input)
            {
                if (!IsValid(currentProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isParsed = DateTime.TryParseExact(currentProject.DueDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime dueDate);

                var project = new Project()
                {
                    Name = currentProject.Name,
                    OpenDate = DateTime.ParseExact(currentProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = isParsed ? (DateTime?)dueDate : null
                };

                foreach (var task in currentProject.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(task.OpenDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(task.DueDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                    if (taskOpenDate < project.OpenDate || taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(new Task()
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(task.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(task.LabelType)
                    });
                }

                projects.Add(project);
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var input = JsonConvert.DeserializeObject<ImportEmployesDto[]>(jsonString);
            var sb = new StringBuilder();
            var employees = new List<Employee>();
            var tasksIds = context.Tasks
                .AsNoTracking()
                .Select(x => x.Id)
                .ToArray();

            foreach (var currentEmployee in input)
            {
                if (!IsValid(currentEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee()
                {
                    Username = currentEmployee.Username,
                    Email = currentEmployee.Email,
                    Phone = currentEmployee.Phone,
                };

                foreach (var task in currentEmployee.Tasks.Distinct())
                {
                    if (!tasksIds.Contains(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = task
                    });
                }

                employees.Add(employee);
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}