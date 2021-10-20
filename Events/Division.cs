using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Division : Event
    {
        // Event Handler
        public static ICalculatorComponent Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent division = new DivisionDecorator(calculator);
            calculator.Operations["division"] = division;

            return calculator;
        }
    }
}
