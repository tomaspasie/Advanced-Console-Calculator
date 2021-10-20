using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.State
{
    // Context Class (State Design Pattern)
    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }
}
