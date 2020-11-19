using System;

namespace CabInvoiceGenerator
{
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab In Voice Gernerator");
            InVoiceGenerator inVoiceGenerator = new InVoiceGenerator(RideType.NORMAL);
            Double fare = inVoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"fare : {fare}");
        }
    }
}
