using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine(calc.CalculateNthPrime(500000));
        }
    }
}
