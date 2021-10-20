using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Iterator
{
    // Aggregate Interface (Iterator Design Pattern)
    internal interface ICalculationCollection
    {
        Iterator CreateIterator();
    }

    // Iterator Interface (Iterator Design Pattern)
    internal interface ICalculationIterator
    {
        void Next(ICalculatorComponent calculator);
        void Previous(ICalculatorComponent calculator);
        void First(ICalculatorComponent calculator);
        void Last(ICalculatorComponent calculator);
        void Current(ICalculatorComponent calculator);
        Calculation CurrentCalculation(ICalculatorComponent calculator);
        void ShowSingle(int i, ICalculatorComponent calculator);
        void ShowAll(ICalculatorComponent calculator);
        void SetTwoVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign);
        void SetOneVariableCalculation(ICalculatorComponent calculator, Calculation updated, String newSign);
        bool EndOfCollection();
    }
}
