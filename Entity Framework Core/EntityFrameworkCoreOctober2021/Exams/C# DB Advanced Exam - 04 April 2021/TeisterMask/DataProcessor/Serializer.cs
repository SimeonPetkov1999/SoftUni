namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var prpjects = context.Projects
                .Include(x=>x.Tasks)
                .ToArray()
                .Where(x => x.Tasks.Any())
                .Select(x => new ExportProjectTasks()
                {
                    TasksCount = x.Tasks.Count(),
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(x => new TaskDto()
                    {
                        Name = x.Name,
                        Label = x.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            var xml = XmlConverter.Serialize(prpjects, "Projects");

            return xml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Include(x=>x.EmployeesTasks)
                .ToArray()
                .Where(x => x.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(x => x.Task.OpenDate >= date)
                    .Select(x => new
                    {
                        TaskName = x.Task.Name,
                        OpenDate = x.Task.OpenDate,
                        DueDate = x.Task.DueDate,
                        LabelType = x.Task.LabelType.ToString(),
                        ExecutionType = x.Task.ExecutionType.ToString(),
                    })
                    .OrderByDescending(x => x.DueDate)
                    .ThenBy(x => x.TaskName)
                    .ToArray()
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10)
                .ToArray();

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                DateFormatString = "d"
            };


            var json = JsonConvert.SerializeObject(employees,settings);

            return json;
        }
    }
}