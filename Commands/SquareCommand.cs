using System;
using System.Collections.Generic;
using System.Text;
using CalculatorProject.Decorators;
using CalculatorProject.Events;
using CalculatorProject.State;
using Microsoft.Extensions.Logging;

namespace CalculatorProject.Commands
{
    // Concrete Command Class (Command Design Pattern)
    class SquareCommand : Command
    {
        private const string Square = "square";
        private const string Choice = "square_USER_CHOICE";

        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Square);
        }
        public override bool UserChoiceCheck(Invoker command)
        {
            return command.OperationString.Equals(Choice);
        }

        public override ICalculatorComponent Execute(Invoker command, ICalculatorComponent calculator)
        {
            bool check = UserInputCheck(command);
            while (check)
            {
                calculator.OnAdd_Square(calculator);
                calculator.TempOperations.Add("Square", new SquareDecorator(calculator));
                calculator = Events.Square.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.Square();

                double a;
                double result;

                Prompts.Number();
                a = Convert.ToDouble(Console.ReadLine());

                calculator.Operations["square"].CreateCalculation(calculator, a);
                result = calculator.Operations["square"].GetResult(calculator);

                Prompts.Result(result);

                calculator.UserOperations.Add("SQUARE OF");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }
    }
}
