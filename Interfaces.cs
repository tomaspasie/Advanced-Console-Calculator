using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Iterator;
using CalculatorProject.State;

namespace CalculatorProject
{
    // Component Interface - Decorator Pattern
    interface ICalculatorComponent
    {
        Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b);
        Calculation CreateCalculation(ICalculatorComponent calculator, double a);
        List<Calculation> CalculationHistory { get; set; }
        List<Invoker> Commands { get; set; }
        List<Invoker> Commands2 { get; set; }
        List<String> UserOperations { get; set; }
        List<Context> CalculatorState { get; set; }
        double GetResult(ICalculatorComponent calculator);
        Dictionary<string, ICalculatorComponent> Operations { get; set; }
        Dictionary<string, ICalculatorComponent> TempOperations { get; set; }
        void OnAdd_Addition(ICalculatorComponent calculator);
        void OnAdd_Subtraction(ICalculatorComponent calculator);
        void OnAdd_Multiplication(ICalculatorComponent calculator);
        void OnAdd_Division(ICalculatorComponent calculator);
        void OnAdd_SquareRoot(ICalculatorComponent calculator);
        void OnAdd_Square(ICalculatorComponent calculator);
    }


}
