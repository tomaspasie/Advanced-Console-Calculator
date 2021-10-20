using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Square : Event
    {
        // Event Handler
        public static ICalculatorComponent Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent square = new SquareDecorator(calculator);
            calculator.Operations["square"] = square;
            
            return calculator;
        }

    }
}
