using System;
using System.Collections.Generic;
using NewTaskScheduller.Models; //this is the class property am using like Name,Description


namespace NewTaskScheduller.Services
{
    public class TaskManager
    {
        private List<ScheduledTask> tasks = new List<ScheduledTask>();
        private FileService fileService;

        public TaskManager()
        {
            fileService = new FileService();
            tasks = fileService.LoadTasks();
        }
        /*-------------------Add Task Method --------------------- */
        public void AddTask()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW TASK ===");
            //Task Name Input with validation untill user enters the right word
            string name;
            do
            {
                Console.Write("Enter task name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name can't be empty and please enter a name without number");
                }
            } while (string.IsNullOrWhiteSpace(name) || name.Any(Char.IsDigit));

            //Description
            string description;
            do
            {
                Console.Write("Enter task description (min 10 characters): ");
                description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description) || description.Length < 10)
                {
                    Console.WriteLine("Description is too short! Try Again!!!");
                }
            } while (string.IsNullOrWhiteSpace(description) || description.Length < 10);

            //Date Deadline input
            DateTime deadline;
            while (true)
            {
                Console.Write("Enter deadline (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out deadline) && deadline >= DateTime.Today)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid or Past Date");
                }
            }

            //storing each task
            ScheduledTask task = new ScheduledTask
            {
                Name = name,
                Description = description,
                Deadline = deadline,
                DateCreated = DateTime.Now,
                IsCompleted = false
            };

            tasks.Add(task);
            Console.WriteLine("Task added! Press Enter to return to menu.");
            Console.ReadLine();
        }
        /*-------------------Add Task Method Ends --------------------- */






        /*-------------------View Pending Task() --------------------- */
        public void ViewPendingTask()
        {
            Console.Clear();
            Console.WriteLine("=== PENDING TASK ===");

            //to filter task and get the incompleted one
            var pendingTasks = tasks.FindAll(t => !t.IsCompleted);

            if (pendingTasks.Count == 0)
            {
                Console.WriteLine("No Pending Task");
            }
            else
            {
                foreach (var task in pendingTasks)
                {
                    Console.WriteLine($"- {task.Name} (Due: {task.Deadline.ToShortDateString()})");
                }
            }
            Console.WriteLine("\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
        /*-------------------View Pending Task() Ends--------------------- */






        /*-------------------View Completed Task()--------------------- */
        public void ViewCompletedTask()
        {
            Console.Clear();
            Console.WriteLine("=== COMPLETED TASKS ===");

            var completed = tasks.FindAll(t => t.IsCompleted);
            if (completed.Count == 0)
            {
                Console.WriteLine("No completed task yet");
            }
            else
            {
                foreach (var task in completed)
                {
                    Console.WriteLine($"{task.Name} | Completed from: {task.DateCreated:yyyy-MM-dd} to {task.Deadline:yyyy-MM-DD}");
                }
            }
            Console.WriteLine("\nPress Enter to return");
            Console.ReadLine();
        }


        /*-------------------View Completed Task() Ends--------------------- */



        /*-------------------Mark Task as Completed--------------------- */

        public void MarkTaskAsCompleted()
        {
            Console.Clear();
            Console.WriteLine("=== MARK TASK AS COMPLETED ===");

            var pending = tasks.FindAll(t => !t.IsCompleted);

            if (pending.Count == 0)
            {
                Console.WriteLine("You've completed all you task. Welldone!!");
                return;
            }

            for (int i = 0; i < pending.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pending[i].Name} - Due: {pending[i].Deadline:yyyy-MM-dd}");
            }

            Console.Write("\nSelect the number of task to mark as completed");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int SelectedIndex) && SelectedIndex >= 1 && SelectedIndex <= pending.Count)
            {
                var taskToMark = pending[SelectedIndex - 1];
                taskToMark.IsCompleted = true;
                fileService.SaveTasks(tasks);
                Console.WriteLine($"'{taskToMark.Name}' is now marked as completed");

            }
            else
            {
                Console.WriteLine("Invalid selection. Nothing was changed");
            }

            Console.WriteLine("Press Enter to return to menu");
            Console.ReadLine();
        }


        /*-------------------Mark Task as Completed Ends--------------------- */

    }
}