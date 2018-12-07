using System;

namespace Aufgabe_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Robin's quiz game!");
            GetSampleQuestions();
            WriteUserInstructions();
            Console.WriteLine("Thank you for playing! Press any key to exit!");
            Console.ReadLine();
        }
        
        private static void GetSampleQuestions()
        {
            //TODO
        }

        private static void WriteUserInstructions()
        {
            Console.WriteLine("Choose one of the following Options\n add) add a question to the quiz\n ask) answer a question \n e) exit quiz");

            
        }

    }

}
