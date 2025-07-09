using System;
using System.Collections.Generic;
using System.IO;
using NewTaskScheduller.Models;

namespace NewTaskScheduller.Services
{
    public class FileService
    {
        private string filePath = "tasks.txt";

        //save task to file
        public void SaveTasks(List<ScheduledTask> tasks)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var task in tasks)
                {
                    string line = $"{task.Name} | {task.Description} | {task.DateCreated} | {task.Deadline} | {task.IsCompleted}";
                    writer.WriteLine(line);
                }
            }
        }
        // load task from file
        public List<ScheduledTask> LoadTasks()
        {
            var tasks = new List<ScheduledTask>();

            if (!File.Exists(filePath))
            {
                return tasks;
            }
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 5)
                {
                    tasks.Add(new ScheduledTask
                    {
                        Name = parts[0],
                        Description = parts[1],
                        DateCreated = DateTime.Parse(parts[2]),
                        Deadline = DateTime.Parse(parts[3]),
                        IsCompleted = bool.Parse(parts[4])
                     });
                }
            }
            return tasks;
        }
    }

   
}