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
    class SquareRootCommand : Command
    {
        private const string SquareRoot = "square root";
        private const string Choice = "square root_USER_CHOICE";

        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(SquareRoot);
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
                calculator.OnAdd_SquareRoot(calculator);
                calculator.TempOperations.Add("Square Root", new SquareRootDecorator(calculator));
                calculator = Events.SquareRoot.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.SquareRoot();

                double a;
                double result;

                Prompts.Number();
                a = Convert.ToDouble(Console.ReadLine());

                calculator.Operations["square root"].CreateCalculation(calculator, a);
                result = calculator.Operations["square root"].GetResult(calculator);

                Prompts.Result(result);

                calculator.UserOperations.Add("SQUARE ROOT OF");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }

    }
}
