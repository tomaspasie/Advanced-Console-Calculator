using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Commands;
using CalculatorProject.Iterator;
using CalculatorProject.Events;
using CalculatorProject.Facade;
using CalculatorProject.History;
using CalculatorProject.State;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using CalculatorProject.Decorators;

namespace CalculatorProject
{
    [TestClass()]
    public class Tests
    {
        // Operation Tests
        [TestMethod()]
        public void AdditionTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent addition = new AdditionDecorator(calculator);

            addition.CreateCalculation(calculator, a, b);
            result = addition.GetResult(calculator);

            //Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent subtraction = new SubtractionDecorator(calculator);

            subtraction.CreateCalculation(calculator, a, b);
            result = subtraction.GetResult(calculator);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void MultiplicationTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent multiplication = new MultiplicationDecorator(calculator);

            multiplication.CreateCalculation(calculator, a, b);
            result = multiplication.GetResult(calculator);

            //Assert
            Assert.AreEqual(25, result);
        }

        [TestMethod()]
        public void DivisionTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent division = new DivisionDecorator(calculator);

            division.CreateCalculation(calculator, a, b);
            result = division.GetResult(calculator);

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void SquareRootTest()
        {
            //Arrange
            double a = 144;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent squareroot = new SquareRootDecorator(calculator);

            squareroot.CreateCalculation(calculator, a);
            result = squareroot.GetResult(calculator);

            //Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod()]
        public void SquareTest()
        {
            //Arrange
            double a = 12;
            double result;

            //Act
            ICalculatorComponent calculator = new Calculator();
            ICalculatorComponent square = new SquareDecorator(calculator);

            square.CreateCalculation(calculator, a);
            result = square.GetResult(calculator);

            //Assert
            Assert.AreEqual(144, result);
        }

        // Decorator Design Pattern Test
        [TestMethod()]
        public void Decorator_DesignPatternTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double c = 144;
            double d = 12;
            double result1, result2, result3, result4, result5, result6;

            //Act
            ICalculatorComponent calculator = new Calculator();

            ICalculatorComponent addition = new AdditionDecorator(calculator);
            ICalculatorComponent subtraction = new SubtractionDecorator(calculator);
            ICalculatorComponent multiplication = new MultiplicationDecorator(calculator);
            ICalculatorComponent division = new DivisionDecorator(calculator);
            ICalculatorComponent squareroot = new SquareRootDecorator(calculator);
            ICalculatorComponent square = new SquareDecorator(calculator);

            addition.CreateCalculation(calculator, a, b);
            result1 = addition.GetResult(calculator);

            subtraction.CreateCalculation(calculator, a, b);
            result2 = subtraction.GetResult(calculator);

            multiplication.CreateCalculation(calculator, a, b);
            result3 = multiplication.GetResult(calculator);

            division.CreateCalculation(calculator, a, b);
            result4 = division.GetResult(calculator);

            squareroot.CreateCalculation(calculator, c);
            result5 = squareroot.GetResult(calculator);

            square.CreateCalculation(calculator, d);
            result6 = square.GetResult(calculator);

            //Assert
            Assert.AreEqual(10, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(25, result3);
            Assert.AreEqual(1, result4);
            Assert.AreEqual(12, result5);
            Assert.AreEqual(144, result6);
        }

        // Command Design Pattern Test
        [TestMethod()]
        public void Command_DesignPatternTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double c = 144;
            double d = 12;
            double result1, result2, result3, result4, result5, result6;

            //Act
            ICalculatorComponent calculator = new Calculator();

            String userInput = "addition";
            Invoker invoker = new Invoker(userInput);
            invoker.Addition.Execute(invoker, calculator);
            calculator.TempOperations["Addition"].CreateCalculation(calculator, a, b);
            result1 = calculator.TempOperations["Addition"].GetResult(calculator);

            userInput = "subtraction";
            invoker = new Invoker(userInput);
            invoker.Subtraction.Execute(invoker, calculator);
            calculator.TempOperations["Subtraction"].CreateCalculation(calculator, a, b);
            result2 = calculator.TempOperations["Subtraction"].GetResult(calculator);

            userInput = "multiplication";
            invoker = new Invoker(userInput);
            invoker.Multiplication.Execute(invoker, calculator);
            calculator.TempOperations["Multiplication"].CreateCalculation(calculator, a, b);
            result3 = calculator.TempOperations["Multiplication"].GetResult(calculator);

            userInput = "division";
            invoker = new Invoker(userInput);
            invoker.Division.Execute(invoker, calculator);
            calculator.TempOperations["Division"].CreateCalculation(calculator, a, b);
            result4 = calculator.TempOperations["Division"].GetResult(calculator);

            userInput = "square root";
            invoker = new Invoker(userInput);
            invoker.SquareRoot.Execute(invoker, calculator);
            calculator.TempOperations["Square Root"].CreateCalculation(calculator, c);
            result5 = calculator.TempOperations["Square Root"].GetResult(calculator);

            userInput = "square";
            invoker = new Invoker(userInput);
            invoker.Square.Execute(invoker, calculator);
            calculator.TempOperations["Square"].CreateCalculation(calculator, d);
            result6 = calculator.TempOperations["Square"].GetResult(calculator);

            //Assert
            Assert.AreEqual(10, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(25, result3);
            Assert.AreEqual(1, result4);
            Assert.AreEqual(12, result5);
            Assert.AreEqual(144, result6);
        }

        // Iterator Design Pattern Test
        [TestMethod()]
        public void Iterator_DesignPatternTest()
        {
            //Arrange
            int i;
            double a = 5;
            double b = 5;
            double c = 144;
            double d = 12;
            double result1, result2, result3, result4, result5, result6;

            //Act
            ICalculatorComponent calculator = new Calculator();

            String userInput = "addition";
            Invoker invoker = new Invoker(userInput);
            invoker.Addition.Execute(invoker, calculator);
            calculator.TempOperations["Addition"].CreateCalculation(calculator, a, b);
            result1 = calculator.TempOperations["Addition"].GetResult(calculator);

            userInput = "subtraction";
            invoker = new Invoker(userInput);
            invoker.Subtraction.Execute(invoker, calculator);
            calculator.TempOperations["Subtraction"].CreateCalculation(calculator, a, b);
            result2 = calculator.TempOperations["Subtraction"].GetResult(calculator);

            userInput = "multiplication";
            invoker = new Invoker(userInput);
            invoker.Multiplication.Execute(invoker, calculator);
            calculator.TempOperations["Multiplication"].CreateCalculation(calculator, a, b);
            result3 = calculator.TempOperations["Multiplication"].GetResult(calculator);

            userInput = "division";
            invoker = new Invoker(userInput);
            invoker.Division.Execute(invoker, calculator);
            calculator.TempOperations["Division"].CreateCalculation(calculator, a, b);
            result4 = calculator.TempOperations["Division"].GetResult(calculator);

            userInput = "square root";
            invoker = new Invoker(userInput);
            invoker.SquareRoot.Execute(invoker, calculator);
            calculator.TempOperations["Square Root"].CreateCalculation(calculator, c);
            result5 = calculator.TempOperations["Square Root"].GetResult(calculator);

            userInput = "square";
            invoker = new Invoker(userInput);
            invoker.Square.Execute(invoker, calculator);
            calculator.TempOperations["Square"].CreateCalculation(calculator, d);
            result6 = calculator.TempOperations["Square"].GetResult(calculator);

            Collection collection = new Collection();

            foreach (Calculation _calculation in calculator.CalculationHistory)
            {
                collection.CalculationHistory.Add(_calculation);
            }

            Iterator.Iterator iterator = collection.CreateIterator();

            iterator.First(calculator);
            i = iterator.GetIndex();
            result1 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            iterator.Next(calculator);
            i = iterator.GetIndex();
            result2 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            iterator.Next(calculator);
            i = iterator.GetIndex();
            result3 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            iterator.Next(calculator);
            i = iterator.GetIndex();
            result4 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            iterator.Next(calculator);
            i = iterator.GetIndex();
            result5 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            iterator.Last(calculator);
            i = iterator.GetIndex();
            result6 = calculator.CalculationHistory[i].Operation(calculator.CalculationHistory[i].A, calculator.CalculationHistory[i].B);

            //Assert
            Assert.AreEqual(10, result1);
            Assert.AreEqual(0, result2);
            Assert.AreEqual(25, result3);
            Assert.AreEqual(1, result4);
            Assert.AreEqual(12, result5);
            Assert.AreEqual(144, result6);
        }

        // Facade Design Pattern Test
        [TestMethod()]
        public void Facade_DesignPatternTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double c = 144;
            double d = 12;
            double result1, result2, result3, result4, result5, result6, test1, test2;

            //Act
            ICalculatorComponent calculator = new Calculator();

            String userInput = "addition";
            Invoker invoker = new Invoker(userInput);
            invoker.Addition.Execute(invoker, calculator);
            calculator.TempOperations["Addition"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("+");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result1 = calculator.TempOperations["Addition"].GetResult(calculator);

            userInput = "subtraction";
            invoker = new Invoker(userInput);
            invoker.Subtraction.Execute(invoker, calculator);
            calculator.TempOperations["Subtraction"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("-");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result2 = calculator.TempOperations["Subtraction"].GetResult(calculator);

            userInput = "multiplication";
            invoker = new Invoker(userInput);
            invoker.Multiplication.Execute(invoker, calculator);
            calculator.TempOperations["Multiplication"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("*");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result3 = calculator.TempOperations["Multiplication"].GetResult(calculator);

            userInput = "division";
            invoker = new Invoker(userInput);
            invoker.Division.Execute(invoker, calculator);
            calculator.TempOperations["Division"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("/");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result4 = calculator.TempOperations["Division"].GetResult(calculator);

            userInput = "square root";
            invoker = new Invoker(userInput);
            invoker.SquareRoot.Execute(invoker, calculator);
            calculator.TempOperations["Square Root"].CreateCalculation(calculator, c);
            calculator.UserOperations.Add("SQUARE ROOT OF");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result5 = calculator.TempOperations["Square Root"].GetResult(calculator);

            userInput = "square";
            invoker = new Invoker(userInput);
            invoker.Square.Execute(invoker, calculator);
            calculator.TempOperations["Square"].CreateCalculation(calculator, d);
            calculator.UserOperations.Add("SQUARE OF");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result6 = calculator.TempOperations["Square"].GetResult(calculator);

            Collection collection = new Collection();

            foreach (Calculation _calculation in calculator.CalculationHistory)
            {
                collection.CalculationHistory.Add(_calculation);
            }

            Iterator.Iterator iterator = collection.CreateIterator();

            iterator.First(calculator);

            // Facade will test for modified and removed calculations. 
            CalculationManipulation manipulator = new CalculationManipulation();
            Calculation oldCalculation = iterator.CurrentCalculation(calculator);
            Calculation newCalculation = manipulator._edit.TwoVariables(oldCalculation, 99, 1, "addition");
            iterator.SetTwoVariableCalculation(calculator, newCalculation, "+");

            test1 = iterator.CurrentCalculation(calculator).Operation(iterator.CurrentCalculation(calculator).A,
                iterator.CurrentCalculation(calculator).B);

            iterator.Next(calculator);
            manipulator.RemoveCalculation(calculator, iterator.GetIndex());

            test2 = calculator.CalculationHistory.Count();


            //Assert
            Assert.AreEqual(100, test1);
            Assert.AreEqual(6, test2);
        }

        // State Design Pattern Test
        [TestMethod()]
        public void State_DesignPatternTest()
        {
            //Arrange
            double a = 5;
            double b = 5;
            double c = 144;
            double d = 12;
            double result1, result2, result3, result4, result5, result6;
            String test1, test2;

            //Act
            ICalculatorComponent calculator = new Calculator();

            String userInput = "addition";
            Invoker invoker = new Invoker(userInput);
            invoker.Addition.Execute(invoker, calculator);
            calculator.TempOperations["Addition"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("+");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result1 = calculator.TempOperations["Addition"].GetResult(calculator);

            userInput = "subtraction";
            invoker = new Invoker(userInput);
            invoker.Subtraction.Execute(invoker, calculator);
            calculator.TempOperations["Subtraction"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("-");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result2 = calculator.TempOperations["Subtraction"].GetResult(calculator);

            userInput = "multiplication";
            invoker = new Invoker(userInput);
            invoker.Multiplication.Execute(invoker, calculator);
            calculator.TempOperations["Multiplication"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("*");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result3 = calculator.TempOperations["Multiplication"].GetResult(calculator);

            userInput = "division";
            invoker = new Invoker(userInput);
            invoker.Division.Execute(invoker, calculator);
            calculator.TempOperations["Division"].CreateCalculation(calculator, a, b);
            calculator.UserOperations.Add("/");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result4 = calculator.TempOperations["Division"].GetResult(calculator);

            userInput = "square root";
            invoker = new Invoker(userInput);
            invoker.SquareRoot.Execute(invoker, calculator);
            calculator.TempOperations["Square Root"].CreateCalculation(calculator, c);
            calculator.UserOperations.Add("SQUARE ROOT OF");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result5 = calculator.TempOperations["Square Root"].GetResult(calculator);

            userInput = "square";
            invoker = new Invoker(userInput);
            invoker.Square.Execute(invoker, calculator);
            calculator.TempOperations["Square"].CreateCalculation(calculator, d);
            calculator.UserOperations.Add("SQUARE OF");
            calculator.CalculatorState.Add(new Context(new Unmodified()));
            result6 = calculator.TempOperations["Square"].GetResult(calculator);

            Collection collection = new Collection();

            foreach (Calculation _calculation in calculator.CalculationHistory)
            {
                collection.CalculationHistory.Add(_calculation);
            }

            Iterator.Iterator iterator = collection.CreateIterator();

            iterator.First(calculator);

            // State will test for both "Unmodified" and "Modified" states of a calculation.
            test1 = calculator.CalculatorState[iterator.GetIndex()].State.GetType().Name;

            CalculationManipulation manipulator = new CalculationManipulation();
            Calculation oldCalculation = iterator.CurrentCalculation(calculator);
            Calculation newCalculation = manipulator._edit.TwoVariables(oldCalculation, 99, 1, "addition");
            iterator.SetTwoVariableCalculation(calculator, newCalculation, "+");

            iterator.CurrentCalculation(calculator).Operation(iterator.CurrentCalculation(calculator).A, iterator.CurrentCalculation(calculator).B);

            test2 = calculator.CalculatorState[iterator.GetIndex()].State.GetType().Name;


            //Assert
            Assert.AreEqual("Unmodified", test1);
            Assert.AreEqual("Modified", test2);
        }
        
    }
}
