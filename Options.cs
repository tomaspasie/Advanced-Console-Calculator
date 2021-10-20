using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Events;
using CalculatorProject.History;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class Options
    {
        public static void Activate(ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            string choice = "";
            while (!choice.Equals("6"))
            {
                Prompts.Options();

                choice = Console.ReadLine();

                CalculationHistory.Activate(calculator, choice);


                // | 3 | Create New Calculations
                while (choice.Equals("3"))
                {
                    WriteToConsole.Write("\n");
                    Receiver.Activate(calculator, logger);
                    choice = "pass";
                }

                // | 4 | Display What The Calculator Is Capable Of Doing (In Its Current State)
                while (choice.Equals("4"))
                {
                    Prompts.Capability();
                    Receiver.DisplayOperations(calculator,"");
                    Prompts.Back();
                    String enter = Console.ReadLine();
                    choice = "pass";
                }

                while ((!choice.Equals("1")) && (!choice.Equals("2")) && (!choice.Equals("3")) && (!choice.Equals("4") && (!choice.Equals("5")) && (!choice.Equals("6")) && (!choice.Equals("pass"))))
                {
                    Prompts.Unavailable();
                    String enter = Console.ReadLine();
                    choice = "pass";
                }

            }
        }
    }
}
