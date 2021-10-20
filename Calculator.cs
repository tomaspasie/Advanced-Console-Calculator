using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Iterator;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    // Delegate Declaration
    delegate void OperationDelegate(ICalculatorComponent calculator);

    class Calculator : ICalculatorComponent
    {
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

        // Calculation Creators
        public Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            return new Calculation();
        }

        public Calculation CreateCalculation(ICalculatorComponent calculator, double a)
        {
            return new Calculation();
        }

        // Calculation History
        public List<Calculation> results = new List<Calculation>();
        List<Calculation> ICalculatorComponent.CalculationHistory { get => results; set => results = new List<Calculation>(); }

        // Command List
        public List<Invoker> commands = new List<Invoker>();
        List<Invoker> ICalculatorComponent.Commands { get => commands; set => commands = new List<Invoker>(); }

        // Command List 2
        public List<Invoker> commands2 = new List<Invoker>();
        List<Invoker> ICalculatorComponent.Commands2 { get => commands2; set => commands2 = new List<Invoker>(); }

        // User Operations List
        public List<String> userOp = new List<String>();
        List<String> ICalculatorComponent.UserOperations { get => userOp; set => userOp = new List<String>(); }

        // Calculator State
        public List<Context> _CalculatorState = new List<Context>();
        List<Context> ICalculatorComponent.CalculatorState { get => _CalculatorState; set => _CalculatorState = new List<Context>(); }

        // Calculation Results [See Decorators]
        public double GetResult(ICalculatorComponent calculator)
        {
            return 0;
        }

        public Dictionary<string, ICalculatorComponent> _operations = new Dictionary<string, ICalculatorComponent> {
            {"addition", null},
            {"subtraction", null},
            {"multiplication", null},
            {"division", null},
            {"square root", null},
            {"square", null}
        };

        Dictionary<string, ICalculatorComponent> ICalculatorComponent.Operations
        {
            get => _operations;
            set => _operations = new Dictionary<string, ICalculatorComponent> { };
        }

        public Dictionary<string, ICalculatorComponent> _tempOperations = new Dictionary<string, ICalculatorComponent> {
            {"addition", null},
            {"subtraction", null},
            {"multiplication", null},
            {"division", null},
            {"square root", null},
            {"square", null}
        };

        Dictionary<string, ICalculatorComponent> ICalculatorComponent.TempOperations
        {
            get => _tempOperations;
            set => _tempOperations = new Dictionary<string, ICalculatorComponent> { };
        }
    }
}
