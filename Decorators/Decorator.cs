using System;
using CalculatorProject.Commands;
using CalculatorProject.Events;

namespace CalculatorProject.Decorators
{
    class Decorator
    {
        public static void Activate(ICalculatorComponent calculator, Publisher publisher)
        {
            bool repeat = true;

            while (repeat)
            {

                Prompts.Functionality();

                String Done = "";
                string operationInput = Console.ReadLine();

                while ((!operationInput.Equals("addition")) && (!operationInput.Equals("subtraction")) && (!operationInput.Equals("multiplication")) && (!operationInput.Equals("division") && (!operationInput.Equals("square root") && (!operationInput.Equals("square")) && (!operationInput.Equals("DONE")))))
                {
                    Prompts.NotAvailable();
                    operationInput = Console.ReadLine();
                }

                while (!Done.Equals("DONE"))
                {
                    Invoker command1 = new Invoker(operationInput);
                    calculator.Commands.Add(command1);
                    Prompts._Functionality();
                    operationInput = Console.ReadLine();
                    while ((!operationInput.Equals("addition")) && (!operationInput.Equals("subtraction")) && (!operationInput.Equals("multiplication")) && (!operationInput.Equals("division") && (!operationInput.Equals("square root") && (!operationInput.Equals("square")) && (!operationInput.Equals("DONE")))))
                    {
                        Prompts.NotAvailable();
                        operationInput = Console.ReadLine();
                    }
                    Done = operationInput;
                    repeat = false;
                }

                Prompts.Divider();
            }

            Invoker finalCommand = new Invoker("Final Command");
            calculator.Commands.Add(finalCommand);

            // Handle User Input
            foreach (Invoker command in calculator.Commands)
            {
                string op = command.OperationString;

                while (op != "Final Command")
                {
                    // Event
                    calculator = publisher.AddFunctionality(command, calculator);
                    op = "Final Command";
                }
            }
        }
    }
}
