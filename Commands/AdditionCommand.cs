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
    class AdditionCommand : Command
    {
        private const string Addition = "addition";
        private const string Choice = "addition_USER_CHOICE";

        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Addition);
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
                calculator.OnAdd_Addition(calculator);
                calculator.TempOperations.Add("Addition", new AdditionDecorator(calculator));
                calculator = Events.Addition.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.Addition();

                double a, b;
                double result;

                Prompts.FirstNumber();
                a = Convert.ToDouble(Console.ReadLine());
                Prompts.SecondNumber();
                b = Convert.ToDouble(Console.ReadLine());

                calculator.Operations["addition"].CreateCalculation(calculator, a, b);
                result = calculator.Operations["addition"].GetResult(calculator);

                Prompts.Result(result);

                calculator.UserOperations.Add("+");
                calculator.CalculatorState.Add(new Context(new Unmodified()));
                check = false;
            }
        }
    }
}
