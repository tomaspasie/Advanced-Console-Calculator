using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class SquareRoot : Event
    {
        // Event Handler
        public static ICalculatorComponent Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent squareroot = new SquareRootDecorator(calculator);
            calculator.Operations["square root"] = squareroot;

            return calculator;
        }
    }
}
