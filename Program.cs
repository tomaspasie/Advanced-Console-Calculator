using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // For Dependency Injection + Logging
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Handles Divide By Zero Condition + Log Entry
            var logger = serviceProvider.GetService<ILogger<CalculatorManager>>();

            // Calculator
            CalculatorManager program = new CalculatorManager(logger);

        }

        // For Dependency Injection + Logging
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole()).AddTransient<CalculatorManager>();
        }


    }
}
