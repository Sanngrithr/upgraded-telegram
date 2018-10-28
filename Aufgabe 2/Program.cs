using System;

namespace Aufgabe_2
{
    class Program
    {
        static void Main(string[] args)
        {
//Datatypes-------------------------------------------------------------------
            Console.WriteLine("---Datatypes---");

            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World";

            Console.WriteLine("i is of type {0}", i.GetType());
            Console.WriteLine("pi is of type {0}", pi.GetType());
            Console.WriteLine("salute is of type {0}", salute.GetType());

//Arrays----------------------------------------------------------------------
            Console.WriteLine("---Arrays---");

            int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6, 0};
            int ergebnis = ia[2] * ia[8] + ia[4];

            Console.WriteLine("Das ergebnis lautet " + ergebnis);
            Console.WriteLine("Länge des Arrays: " + ia.Length);

            double[] constants = {Math.PI, Math.E, 2.97E-19};

//Strings----------------------------------------------------------------------
            Console.WriteLine("---Strings---");

            string meinString = "Dies ist ein String";
            string a1 = "Dies ist ";
            string b1 = "ein String";
            string c1 = a1 + b1;
            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);
            char zeichen = meinString[5];

            Console.WriteLine("meinString = " + meinString);
            Console.WriteLine("c1 = " + c1);
            Console.WriteLine("a_eq_b = " + a_eq_b);
            Console.WriteLine("a_eq_c = " + a_eq_c);
            Console.WriteLine("zeichen = " + zeichen);

//if/else----------------------------------------------------------------------
            Console.WriteLine("---if/else---");

            Console.WriteLine();
            Console.WriteLine("Input 2 integer numbers:");
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());

            if(input1 > 3 && input2 == 6)
            {
                Console.WriteLine("You win!");
            }
            else if(input1 > input2)
            {
                Console.WriteLine(input1 + " is greater than " + input2);
            }
            else if(input2 > input1)
            {
                Console.WriteLine(input2 + " is greater than " + input1);
            }
        
//switch/case------------------------------------------------------------------
            Console.WriteLine("---switch/case---");

            Console.WriteLine("Input a number from 1 to 10");
            string s = Console.ReadLine();
            switch (s)
            {
            case "1":
                Console.WriteLine("Du hast EINS eingegeben");
                break;
            case "2":
                Console.WriteLine("ZWEI war Deine Wahl");
                break;
            case "3":
                Console.WriteLine("Du tipptest eine DREI");
                break;
            case "7":
                Console.WriteLine("SIEBEN ist die beste Zahl!");
                break;
            default:
                Console.WriteLine("Die Zahl " + s + " kenne ich nicht");
                break;
            }

            if(s == "1")
            {
                Console.WriteLine("Du hast EINS eingegeben");
            }
            else if(s == "2")
            {
                Console.WriteLine("ZWEI war Deine Wahl");
            }
            else if(s == "3")
            {
                Console.WriteLine("Du tipptest eine DREI");
            }
            else if(s == "7")
            {
                Console.WriteLine("SIEBEN ist die beste Zahl!");
            }
            else
            {
                Console.WriteLine("Die Zahl " + s + " kenne ich nicht");
            }

//Loops-----------------------------------------------------------------------------
            Console.WriteLine("---Loops---");
            
            short t = 1;

            while(t <= 10)
            {
                Console.WriteLine(t);
                t++;
            }

            string[] someStrings = 
            {
                "Hier",
                "sehen",
                "wir",
                "einen",
                "Array",
                "von",
                "Strings"
            };
            
            for (int k = 0; k < someStrings.Length; k++)
            {
                Console.WriteLine(someStrings[k]);
            }
        }
    }
}
