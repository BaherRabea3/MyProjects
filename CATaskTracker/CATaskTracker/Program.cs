namespace CATaskTracker
{
    internal class Program
    {
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            string[] Requirments = {"Add Task", "View tasks", "Update tasks", "Remove tasks","Exit"};
            int hover = 0;
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                for (int i = 0; i < Requirments.Length; i++)
                {
                    Console.SetCursorPosition(60, 3 * i + 2);
                    if (i == hover)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.WriteLine(Requirments[i]);
                    Console.ResetColor();
                }
                ConsoleKeyInfo input = Console.ReadKey();
                ConsoleKey key = input.Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        hover = hover <= 0 ? Requirments.Length - 1 : --hover;
                        break;
                    case ConsoleKey.DownArrow:
                        hover = hover >= Requirments.Length - 1 ? 0 : ++hover;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (hover)
                        {
                            case 0:
                                AddTask();
                                break;
                            case 1:
                                ViewTasks();
                                break;
                            case 2:
                                UpdateTasks();
                                break;
                            case 3:
                                RemoveTask();
                                break;
                            case 4:
                                Console.WriteLine("Are you sure you want to exit? (y , n)");
                                char exit = char.Parse(Console.ReadLine());
                                if (exit == 'y')
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            default:
                                break;
                        }
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                
            } // end of while

        }// end of main
        public static void AddTask()
        {
            Console.WriteLine("Enter task title");
            string? Title = Console.ReadLine();
            Console.WriteLine("Enter task description");
            string? Description = Console.ReadLine();
            Console.WriteLine("Enter task due date in format -> (dd/mm/yyyy)");
            DateTime dateTime = DateTime.TryParse(Console.ReadLine(), out dateTime) ? dateTime: DateTime.Now;
            Console.WriteLine("Choose the periority number of the task >> 1) Urgent  2) Normal");
            int PriorNum;
            Periority periority = int.TryParse(Console.ReadLine(), out PriorNum) ? (Periority)PriorNum : 0;
            tasks.Add(new Task(Title, Description, dateTime, periority));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task added successfully");
        }

        public static void UpdateTasks()
        {
            foreach(Task task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine("Update task status(  1) In progress  2) Completed ) ");
                task.status = int.TryParse(Console.ReadLine(), out var status) ? (Status)status : 0;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task updated successfully");
        }

        public static void ViewTasks()
        {
            Console.WriteLine("Completed Tasks :");
            foreach (var task in tasks)
            {
                if (task.status == Status.Completed)
                    Console.WriteLine(task);
            }
            Console.WriteLine("-------------------");
            Console.WriteLine("Active Tasks :");
            foreach (var task in tasks)
            {
                if (task.status == Status.InProgress)
                    Console.WriteLine(task);
            }
        }

        public static void DisplayAllTasks()
        {
            int index = 1;
            foreach (var task in tasks)
            {
                Console.WriteLine($"{index++}) title: {task.Title}  status: {task.status}");
            }
            Console.WriteLine("-----------------------");
        }
        public static void RemoveTask()
        {
            DisplayAllTasks();
            Console.WriteLine("Which task do you want to remove?");
            int remove = int.Parse(Console.ReadLine());
            tasks.RemoveAt(remove - 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Task removed");
        }
    }
}
