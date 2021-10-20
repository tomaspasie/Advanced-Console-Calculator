using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Decorators;
using CalculatorProject.Events;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class ConsoleManager
    {
        // Console Manager
        public static void Activate(ICalculatorComponent calculator, Publisher publisher, ILogger<CalculatorManager> logger)
        {
            Prompts.Intro();

            // User adds functionality to calculator.
            Decorator.Activate(calculator, publisher);

            // User chooses the operation they want to calculate from the functionality they added to the calculator and performs calculations.
            Receiver.Activate(calculator, logger);

            // User is displayed options to view the calculation history if different formats, perform another calculation, or exit the program.
            Options.Activate(calculator, logger);

            Prompts.Outro();
        }
    }
}
