using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;

namespace CalculatorProject.Events
{
    class Addition : Event
    {
        // Event Handler
        public static ICalculatorComponent Handler(ICalculatorComponent calculator)
        {
            ICalculatorComponent addition = new AdditionDecorator(calculator);
            calculator.Operations["addition"] = addition;
            
            return calculator;
        }
    }
}
