using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Command Abstract Class
    abstract class Command
    {
        public abstract bool UserInputCheck(Invoker command);
        public abstract bool UserChoiceCheck(Invoker command);
        public abstract ICalculatorComponent Execute(Invoker command, ICalculatorComponent calculator);
        public abstract void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger);
    }
}
