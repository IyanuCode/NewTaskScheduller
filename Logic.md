
# PROJECT: A console-based task scheduler that supports adding tasks with deadlines, marking tasks as complete, and viewing pending and completed tasks, with all tasks saved for later access.

# The app will:
<!--
     Add a new task with a deadline and description

     Prevent duplicate task names

     Mark a task as complete

     Show pending vs. completed tasks

     Save and load tasks from a persistent storage file

     Validate input (text checks, required deadlines, character length)
-->
# Modular Architecture:
<!--
Module	            Responsibility
Task	            Represents a single task
TaskManager	        Add, mark complete, check for duplicates
FileService	        Save/load task list from file(txt)
ReportGenerator	    Display formatted lists: pending and completed tasks
Validator	        Input checks for task name, description, deadline
Program.cs	        Main menu logic, receives input and delegates to other modules
-->

# Data Structures
<!--
    public class Task
    {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsCompleted { get; set; }
    }
-->

# FlowChart Overview
<!--
    [Main Menu]
    ├── Add New Task
    │     └── Validate Input → Check Duplicate → Save to File
    ├── View Pending Tasks
    │     └── Load → Filter by IsCompleted = false → Display
    ├── View Completed Tasks
    │     └── Load → Filter by IsCompleted = true → Display
    ├── Mark Task as Completed
    │     └── Load → Select by Name → Update → Save
    └── Exit
-->

# Validation
<!--
Field	        Rule
Task Name	    Must be text, not empty, no duplicates
Description	    Text only, minimum 10–15 characters
Deadline	    Must be a valid date, not in the past
-->

# Possible Method List
<!--
Method	                    Purpose
AddTask()	                Collect and validate input, create task
ValidateTaskInput()	        Run all validation logic
ViewPendingTasks()	        Filter and display IsCompleted == false
ViewCompletedTasks()	    Filter and display IsCompleted == true
MarkTaskComplete()	        Change status of a task by name
SaveToFile()	            Serialize tasks and save to file
LoadFromFile()	            Load tasks into memory (List<Task>)
CheckForDuplicate()	        Returns true if task with same name already exists
-->

<!-->
NewTaskScheduler/          ← Root project folder
├── Models/                ← Holds data classes like Task.cs
│   └── Task.cs
│
├── Services/              ← Handles logic: adding, marking, saving, loading
│   ├── TaskManager.cs
│   ├── FileService.cs
│   └── ReportGenerator.cs
│
├── Utilities/             ← Reusable utilities like validations
│   └── Validator.cs
│
├── Program.cs             ← Entry point: Main() and Menu logic
└── tasks.txt    
