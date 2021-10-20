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
    class DivisionCommand : Command
    {
        private const string Division = "division";
        private const string Choice = "division_USER_CHOICE";

        public override bool UserInputCheck(Invoker command)
        {
            return command.OperationString.Equals(Division);
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
                calculator.OnAdd_Division(calculator);
                calculator.TempOperations.Add("Division", new DivisionDecorator(calculator));
                calculator = Events.Division.Handler(calculator);
                check = false;
            }

            return calculator;
        }

        public override void ExecuteConsole(Invoker command, ICalculatorComponent calculator, ILogger<CalculatorManager> logger)
        {
            bool check = UserChoiceCheck(command);
            while (check)
            {
                Prompts.Division();

                double a, b;
                int c, d;
                double result, test;
                bool skip = false;

                Prompts.FirstNumber();
                a = Convert.ToDouble(Console.ReadLine());
                c = (int)a;

                Prompts.SecondNumber();
                b = Convert.ToDouble(Console.ReadLine());
                d = (int)b;

                // Handles Divide By Zero Condition + Log Entry
                try
                {
                    test = c / d;
                }
                catch (DivideByZeroException e)
                {
                    skip = true;
                    Prompts.Logger();
                    logger.LogInformation(e.Message);

                }

                while ((skip.Equals(false)) && (b != 0))
                {
                    calculator.Operations["division"].CreateCalculation(calculator, a, b);
                    result = calculator.Operations["division"].GetResult(calculator);

                    Prompts.Result(result);

                    calculator.UserOperations.Add("/");
                    calculator.CalculatorState.Add(new Context(new Unmodified()));
                    check = false;
                    skip = true;
                }

                check = false;
                skip = false;
            }
        }

    }
}
