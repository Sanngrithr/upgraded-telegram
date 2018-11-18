using System;

namespace Aufgabe_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ReverseLettersOnly(args);
            ReverseWordOrder(args);
            ReverseEverything(args);
        }

        static void ReverseWordOrder(String[] args)
        {
            string answer = "";

            for(int i = args.Length -1; i >= 0; i--)
            {
                answer = answer + args[i] + " ";
            }
            Console.WriteLine(answer);
        }

        static void ReverseEverything(String[] args)
        {
            string answer = "";

            for(int i = args.Length -1; i >= 0; i--)
            {
                for(int j = args[i].Length - 1; j >= 0; j--)
                {
                    answer = answer + args[i][j];
                }

                answer = answer + " ";
            }

            Console.WriteLine(answer);
        }

        static void ReverseLettersOnly(String[] args)
        {
            string answer = "";

            for(int i = 0; i < args.Length; i++)
            {
                for(int j = args[i].Length - 1; j >= 0; j--)
                {
                    answer = answer + args[i][j];
                }

                answer = answer + " ";
            }

            Console.WriteLine(answer);
        }
    }
}
