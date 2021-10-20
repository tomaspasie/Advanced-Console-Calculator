using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Events;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Receiver Class (Command Design Pattern)
    class Receiver
    {
        public static void Activate(ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            string another = "YES";
            while (!another.Equals("NO"))
            {
                Prompts.ChooseOperation();

                string options = "";
                DisplayOperations(calculator, options);

                string choice = Console.ReadLine();
                Invoker command2 = new Invoker(choice + "_USER_CHOICE");
                Invoker finalCalculation = new Invoker("Final Calculation");
                calculator.Commands2.Add(command2);
                calculator.Commands2.Add(finalCalculation);

                // Handle User Input
                string last = "";
                foreach (Invoker command in calculator.Commands2)
                {
                    while (!last.Equals("Final Calculation"))
                    {
                        command.Addition.ExecuteConsole(command, calculator, logger);
                        command.Subtraction.ExecuteConsole(command, calculator, logger);
                        command.Multiplication.ExecuteConsole(command, calculator, logger);
                        command.Division.ExecuteConsole(command, calculator, logger);
                        command.SquareRoot.ExecuteConsole(command, calculator, logger);
                        command.Square.ExecuteConsole(command, calculator, logger);
                        last += "Final Calculation";
                    }
                }

                Prompts.Another();
                another = Console.ReadLine();
                calculator.Commands2.Clear();
                options = "";
            }
        }

        public static void DisplayOperations(ICalculatorComponent calculator, String options)
        {
            foreach (Invoker command in calculator.Commands)
            {
                string op = command.OperationString;

                while (op != "Final Command")
                {
                    options += command.OperationString;
                    options += ",";
                    op = "Final Command";
                }
            }

            options = options.Replace(",", " | ");
            WriteToConsole.Write($"| {options}\n");
        }
    }
}
