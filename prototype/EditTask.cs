using System;
using System.Collections.Generic;

public static class EditTask
{
    public static void Edit(List<ToDoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("You have no current tasks, that you can edit.");
            return;
        }
        
        Console.WriteLine("Pick a task number to edit: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
        }

        string taskEditChoice = Console.ReadLine();

        if (int.TryParse(taskEditChoice, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid task number!");
                return;
            }

            Console.WriteLine("What do you wanna change?");
            Console.WriteLine("1. Edit title");
            Console.WriteLine("2. Edit description");
            Console.WriteLine("3. Edit properties");

            string editChoice = Console.ReadLine();

            if (editChoice == "1")
            {
                Console.WriteLine("New title: ");
                string newTitle = Console.ReadLine();

                tasks[index].Title = newTitle;
                Console.WriteLine("Title now updated!");
            }
            else if (editChoice == "2")
            {
                Console.WriteLine("New description: ");
                string newDescription = Console.ReadLine();

                tasks[index].Text = newDescription;
                Console.WriteLine("Description now updated");
            }
            else if (editChoice == "3")
            {
                if (tasks[index].Properties.Count == 0)
                {
                    Console.WriteLine("This task doesn't have any properties yet!");
                    return;
                }

                for (int i = 0; i < tasks[index].Properties.Count; i++)
                {
                    Console.Write($"{i + 1}. ");
                    tasks[index].Properties[i].ShowProperty();
                }

                Console.WriteLine("Which property do you wanna change?: ");
                string newProperty = Console.ReadLine();

                if (int.TryParse(newProperty, out int propertyNum))
                {
                    int propertyIndex = propertyNum - 1;

                    if (propertyIndex < 0 || propertyIndex >= tasks[index].Properties.Count)
                    {
                        Console.WriteLine("Invalid property number!");
                        return;
                    }

                    tasks[index].Properties.RemoveAt(propertyIndex);

                    Console.WriteLine("What should the new property be?");
                    Console.WriteLine("1. A deadline");
                    Console.WriteLine("2. A member");
                    Console.WriteLine("3. Some text");
                    Console.WriteLine("4. A location");

                    string newChoice = Console.ReadLine();

                    if (newChoice == "1")
                    {
                        Console.WriteLine("Enter a new deadline (dd-MM-yyyy): ");

                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newDeadline))
                        {
                            tasks[index].AddProperty(new DeadlineProperty(newDeadline));
                            Console.WriteLine("New deadline set!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format!");
                        }
                    }
                    else if (newChoice == "2")
                    {
                        Console.WriteLine("Enter a new member: ");
                        string newMemberName = Console.ReadLine();
                        tasks[index].AddProperty(new MemberProperty(new Member(newMemberName)));
                        Console.WriteLine("New member set!");
                    }
                    else if (newChoice == "3")
                    {
                        Console.WriteLine("Enter a new property name: ");
                        string newPropName = Console.ReadLine();

                        Console.WriteLine("Enter a new property value: ");
                        string newPropValue = Console.ReadLine();

                        tasks[index].AddProperty(new TextProperty(newPropName, newPropValue));
                        Console.WriteLine("New property set!");
                    }
                    else if (newChoice == "4")
                    {
                        Console.WriteLine("Enter a new location: ");
                        string newLocation = Console.ReadLine();

                        tasks[index].AddProperty(new LocationProperty(newLocation));
                        Console.WriteLine("New location set!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
                else
                {
                    Console.WriteLine("You need to type a valid number!");
                }
            } 
        }
        else
        {
            Console.WriteLine("You must type a number!");
        }
    }
}