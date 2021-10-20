using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Multiplication : Event
    {
        // Event Handler
        public static ICalculatorComponent Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent multiplication = new MultiplicationDecorator(calculator);
            calculator.Operations["multiplication"] = multiplication;

            return calculator;
        }
    }
}
