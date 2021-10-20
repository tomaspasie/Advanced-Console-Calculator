using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.Iterator
{
    // Concrete Aggregate Class (Iterator Design Pattern)
    class Collection : ICalculationCollection
    {
        public ArrayList CalculationHistory = new ArrayList();

        // Create Iterator
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        // Total Count of Stored Calculations
        public int Count
        {
            get { return CalculationHistory.Count; }
        }

        // Calculation Indexer
        public object this[int index]
        {
            get { return CalculationHistory[index]; }
            set { CalculationHistory.Add(value); }
        }
        
    }
}
