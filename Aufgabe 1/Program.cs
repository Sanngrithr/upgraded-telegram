using System;

namespace Aufgabe_1
{
    class Program
    {
        static int anumber; //stores the arabic number
        static string rnumber = ""; //stores the roman number
        
        static void Main(string[] args)
        {
            //check whether or not the user input was a legal int value
            if(Int32.TryParse(args[0], out anumber))
            {
                if(anumber <= 999 && anumber >= 1)
                {
                    anumber = Int32.Parse(args[0]);

                    GetRomanNumber(anumber);

                    Console.WriteLine(rnumber);
                }
                else
                {
                    Console.WriteLine("Value must be within the range of 1-999");
                }
            }
            else
            {
                Console.WriteLine("args[0] not an integer");
            }
        }

        /*This Method takes the anumber value and creates a roman number string in rnumber */
        public static void GetRomanNumber(int anumber)
        {
            Get1(anumber);
            Get10(anumber);
            Get100(anumber);
        }

        public static void Get100(int number)
        {
             string temp = "";

            if(number % 1000 >= 900)
            {
                temp = "CM";
                number -= 900;
            }
            if(number % 500 >= 400)
            {
                temp = "CD";
                number -= 400;
            }
            if(number % 1000 >= 500)
            {
                temp = "D";
                number -= 500;
            }
            while(number % 500 >= 100)
            {
                temp = temp + "C";
                number -= 100;
            }
            rnumber = temp + rnumber;
        }

        public static void Get10(int number)
        {
            string temp = "";

            if(number % 100 >= 90)
            {
                temp = "XC";
                number -= 90;
            }
            if(number % 50 >= 40)
            {
                temp = "XL";
                number -= 40;
            }
            if(number % 100 >= 50)
            {
                temp = "L";
                number -= 50;
            }
            while(number % 50 >= 10)
            {
                temp = temp + "X";
                number -= 10;
            }
            rnumber = temp + rnumber;
        }

        public static void Get1(int number)
        {
            string temp = "";

            if(number % 10 == 9)
            {
                temp = "IX";
                number -= 9;
            }
            if(number % 5 == 4)
            {
                temp = "IV";
                number -= 4;
            }
            if(number % 10 >= 5)
            {
                temp = "V";
                number -= 5;
            }
            while(number % 5 != 0)
            {
                temp = temp + "I";
                number -= 1;
            }
            rnumber = temp + rnumber;
        }
    }
}
