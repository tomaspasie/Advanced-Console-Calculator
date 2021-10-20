using System;

namespace CalculatorProject.Events
{
    class Subscriber
    {
        private readonly Publisher _publishers;
        public Subscriber(Publisher publisher)
        {
            this._publishers = publisher;
            _publishers.AddOperation += Publishers_AddOperation;
        }

        public static void Publishers_AddOperation(object sender, EventArgs e)
        {
            WriteToConsole.Write("\n| Event: " + sender.ToString().ToUpper() + " Operation Added.");
        }
        
        public void UnSubscribeEvent()
        {
            _publishers.AddOperation -= Publishers_AddOperation;
        }
    }
}
