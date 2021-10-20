using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    // Concrete Square Root Decorator (Decorator Design Pattern)
    class SquareRootDecorator : CalculatorDecorator
    {
        public SquareRootDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a)
        {
            var squareRoot = Calculation.Create(a, 0, Operations.SquareRoot, calculator);

            return squareRoot;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A,0);
        }
    }
}