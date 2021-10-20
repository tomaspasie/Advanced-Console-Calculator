using CalculatorProject.Iterator;

namespace CalculatorProject.Decorators
{
    class DivisionDecorator : CalculatorDecorator
    {
        // Concrete Division Decorator (Decorator Design Pattern)
        public DivisionDecorator(ICalculatorComponent calculator) : base(calculator) { }

        public override Calculation CreateCalculation(ICalculatorComponent calculator, double a, double b)
        {
            var quotient = Calculation.Create(a, b, Operations.Division, calculator);

            return quotient;
        }

        public override double GetResult(ICalculatorComponent calculator)
        {
            return calculator.CalculationHistory[^1].Operation(calculator.CalculationHistory[^1].A, calculator.CalculationHistory[^1].B);
        }
    }
}