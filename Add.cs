using System;
using System.Collections.Generic;
using ToDoApplication.Models.properties;
using ToDoApplication.Models;

public static class AddTask
{
    public static void Add(List<ToDoTask> tasks)
    {
        Console.WriteLine("Task name: ");
        string taskName = Console.ReadLine();

        Console.WriteLine("Task description: ");
        string taskDespriction = Console.ReadLine();

        ToDoTask newTask = new ToDoTask(taskName, taskDespriction);
        tasks.Add(newTask);

        Console.WriteLine("Task added!");
    }    
}

public static class AddProperty
{
    public static void Add(List<ToDoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No current tasks.");
            return;
        }

        Console.WriteLine("Pick a task number: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
        }

        Console.WriteLine("Task number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid task number!");
                return;
            }
            else
            {
                Console.WriteLine("Do you wanna add:\n");
                Console.WriteLine("1. A Deadline\n");
                Console.WriteLine("2. A member\n");
                Console.WriteLine("3. A location\n");
                Console.WriteLine("4. A priority\n");
                Console.WriteLine("5. Or some text\n");

                string propertyChoice = Console.ReadLine();

                if (propertyChoice == "1")
                {
                    Console.WriteLine("Deadline (form: dd-MM-yyyy): ");
                    string dateInput = Console.ReadLine();

                    if (DateTime.TryParse(dateInput, out DateTime addedDeadline))
                    {
                        tasks[index].AddProperty(new DeadlineProperty(addedDeadline));
                        Console.WriteLine("Deadline added!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format! Please try again.");
                    }
                    tasks[index].AddProperty(new DeadlineProperty(addedDeadline));
                }
                else if (propertyChoice == "2")
                {
                    Console.WriteLine("Name of the member: ");
                    string memberName = Console.ReadLine();

                    Member newMember = new Member(memberName);

                    tasks[index].AddProperty(new MemberProperty(newMember));
                    Console.WriteLine("Member added!");
                }
                else if (propertyChoice == "3")
                {
                    Console.WriteLine("Location: ");
                    string locationInput = Console.ReadLine();

                    tasks[index].AddProperty(new LocationProperty(locationInput));
                    Console.WriteLine("Location added!");
                }
                else if (propertyChoice == "4")
                {
                    Console.WriteLine("Pick a priority:\n1. Low\n2. Medium\n3. High");
                    string priorityInput = Console.ReadLine();

                    PriorityProperty.PriorityLevel chosenLevel;

                    if (priorityInput == "1")
                    {
                        chosenLevel = PriorityProperty.PriorityLevel.Low;
                    }
                    else if (priorityInput == "2")
                    {
                        chosenLevel = PriorityProperty.PriorityLevel.Medium;
                    }
                    else
                    {
                        chosenLevel = PriorityProperty.PriorityLevel.High;
                    }
                    tasks[index].AddProperty(new PriorityProperty(chosenLevel));
                    Console.WriteLine("Priority added!");
                }
                else if (propertyChoice == "5")
                {
                    Console.WriteLine("Property name: ");
                    string propertyName = Console.ReadLine();

                    Console.WriteLine("Property value: ");
                    string propertyValue = Console.ReadLine();

                    tasks[index].AddProperty(new TextProperty(propertyName, propertyValue));            
                    Console.WriteLine("Property added!");
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input, you must type a number!"); 
            return;
        }
    }
}