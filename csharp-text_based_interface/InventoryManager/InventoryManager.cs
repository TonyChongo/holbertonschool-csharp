using System;
using InventoryLibrary;

namespace InventoryManager
{
    class Program
    {
        static JSONStorage storage = new JSONStorage();

        static void Main(string[] args)
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine("-------------------------");

            storage.Load(); // Load objects from JSONStorage

            while (true)
            {
                Console.WriteLine("Available Commands:");
                Console.WriteLine("<ClassNames> - Show all ClassNames of objects");
                Console.WriteLine("<All> - Show all objects");
                Console.WriteLine("<All [ClassName]> - Show all objects of a ClassName");
                Console.WriteLine("<Create [ClassName]> - Create a new object");
                Console.WriteLine("<Show [ClassName object_id]> - Show an object");
                Console.WriteLine("<Update [ClassName object_id]> - Update an object");
                Console.WriteLine("<Delete [ClassName object_id]> - Delete an object");
                Console.WriteLine("<Exit> - Quit the application");
                Console.Write("Enter a command: ");
                string input = Console.ReadLine().Trim().ToLower();

                string[] parts = input.Split(' ');
                string command = parts[0];

                if (command == "classnames")
                {
                    PrintClassNames();
                }
                else if (command == "all")
                {
                    if (parts.Length == 1)
                    {
                        PrintAllObjects();
                    }
                    else if (parts.Length == 2)
                    {
                        string className = parts[1];
                        PrintAllObjectsByClassName(className);
                    }
                    else
                    {
                        PrintInvalidCommandError();
                    }
                }
                else if (command == "create")
                {
                    if (parts.Length == 2)
                    {
                        string className = parts[1];
                        CreateObject(className);
                    }
                    else
                    {
                        PrintInvalidCommandError();
                    }
                }
                else if (command == "show")
                {
                    if (parts.Length == 3)
                    {
                        string className = parts[1];
                        string objectId = parts[2];
                        ShowObject(className, objectId);
                    }
                    else
                    {
                        PrintInvalidCommandError();
                    }
                }
                else if (command == "update")
                {
                    if (parts.Length == 3)
                    {
                        string className = parts[1];
                        string objectId = parts[2];
                        UpdateObject(className, objectId);
                    }
                    else
                    {
                        PrintInvalidCommandError();
                    }
                }
                else if (command == "delete")
                {
                    if (parts.Length == 3)
                    {
                        string className = parts[1];
                        string objectId = parts[2];
                        DeleteObject(className, objectId);
                    }
                    else
                    {
                        PrintInvalidCommandError();
                    }
                }
                else if (command == "exit")
                {
                    storage.Save(); // Save objects to JSONStorage
                    Environment.Exit(0);
                }
                else
                {
                    PrintInvalidCommandError();
                }
            }
        }

        // Define the command methods here as described in the prompt.

        // PrintClassNames
        // PrintAllObjects
        // PrintAllObjectsByClassName
        // CreateObject
        // ShowObject
        // UpdateObject
        // DeleteObject
        // PrintInvalidCommandError
    }
}
