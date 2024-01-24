using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Controller controller = new Controller();
        string command;

        do
        {
            Console.Write("Enter command: ");
            command = Console.ReadLine();
            string result = controller.ProcessCommand(command);
            Console.WriteLine(result);
        } while (command.ToLower() != "end");
    }
}