using NewTaskScheduller.Services;  // gives me access to classes in this namespace

namespace NewTaskScheduller
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager(); //having obtain access, am selecting the class i want to use, there can be many classes therein

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TASK SCHEDULER ===");
                Console.WriteLine("To Add New Task, Press 1");
                Console.WriteLine("To View Pending Task, Press 2");
                Console.WriteLine("To View Completed Task, Press 3");
                Console.WriteLine("To Mark Task As Completed, Press 4");
                Console.WriteLine("Press 5 To Exit");
                Console.Write("Choose an option: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        taskManager.AddTask();
                        break;
                    case "2":
                        taskManager.ViewPendingTask();
                        break;
                    case "3":
                        taskManager.ViewCompletedTask();
                        break;
                    case "4":
                        taskManager.MarkTaskAsCompleted();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again!");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}