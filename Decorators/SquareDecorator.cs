using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Square Decorator (Decorator Design Pattern)
    class SquareDecorator : CalculatorDecorator
    {
        public SquareDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a)
        {
            var square = Calculation.Create(a, 0, Operations.Square, calculator);

            return square;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A, 0);
        }
    }
}