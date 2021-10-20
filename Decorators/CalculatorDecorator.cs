using System;
using System.Collections.Generic;
using CalculatorProject.Commands;
using CalculatorProject.Iterator;
using CalculatorProject.State;

namespace CalculatorProject.Decorators
{
    // Decorator Structural Design Pattern - Used to add functionality to calculator.

    // Base Decorator
    class CalculatorDecorator : ICalculatorComponent
    {
        private ICalculatorComponent source;

        public CalculatorDecorator(ICalculatorComponent calculator)
        {
            source = calculator;
        }

        public virtual Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            return source.CreateCalculation(calculator, a, b);
        }

        public virtual Calculation CreateCalculation(ICalculatorComponent calculator, double a)
        {
            return source.CreateCalculation(calculator, a);
        }

        public virtual double GetResult(ICalculatorComponent calculator)
        {
            return source.GetResult(calculator);
        }

        List<Calculation> ICalculatorComponent.CalculationHistory { get => new List<Calculation>(); set => new List<Calculation>(); }
        List<Invoker> ICalculatorComponent.Commands { get => new List<Invoker>(); set => new List<Invoker>(); }
        List<Invoker> ICalculatorComponent.Commands2 { get => new List<Invoker>(); set => new List<Invoker>(); }
        List<String> ICalculatorComponent.UserOperations { get => new List<String>(); set => new List<String>(); }
        List<Context> ICalculatorComponent.CalculatorState { get => new List<Context>(); set => new List<Context>(); }

        Dictionary<string, ICalculatorComponent> ICalculatorComponent.Operations
        {
            get => new Dictionary<string, ICalculatorComponent> { }; set => new Dictionary<string, ICalculatorComponent> { };
        }

        Dictionary<string, ICalculatorComponent> ICalculatorComponent.TempOperations
        {
            get => new Dictionary<string, ICalculatorComponent> { }; set => new Dictionary<string, ICalculatorComponent> { };
        }

        // Event Declaration
        public event OperationDelegate AddAddition;
        public event OperationDelegate AddSubtraction;
        public event OperationDelegate AddMultiplication;
        public event OperationDelegate AddDivision;
        public event OperationDelegate AddSquareRoot;
        public event OperationDelegate AddSquare;

        public void OnAdd_Addition(ICalculatorComponent calculator)
        {
            AddAddition?.Invoke(calculator);
        }

        public void OnAdd_Subtraction(ICalculatorComponent calculator)
        {
            AddSubtraction?.Invoke(calculator);
        }

        public void OnAdd_Multiplication(ICalculatorComponent calculator)
        {
            AddMultiplication?.Invoke(calculator);
        }

        public void OnAdd_Division(ICalculatorComponent calculator)
        {
            AddDivision?.Invoke(calculator);
        }

        public void OnAdd_SquareRoot(ICalculatorComponent calculator)
        {
            AddSquareRoot?.Invoke(calculator);
        }

        public void OnAdd_Square(ICalculatorComponent calculator)
        {
            AddSquare?.Invoke(calculator);
        }

    }
}