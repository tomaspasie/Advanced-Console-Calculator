using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Facade
{
    // Subsystem ClassB (Facade Design Pattern)
    class Remove
    {
        public void Execute(ICalculatorComponent calculator, int index)
        {
            calculator.CalculationHistory.RemoveAt(index);
        }
    }
}
