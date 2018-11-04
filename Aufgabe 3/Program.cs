using System;

namespace Aufgabe_3
{
    class Program
    {
        static int from;
        static int to;
        static int number;
        static void Main(string[] args)
        {
            Console.WriteLine("Number System Converter");
            Console.WriteLine("Please input the system yout want to convert FROM...");
            from = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please input the system yout want to convert TO...");
            to = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please input yout number...");
            number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Your Result : "  + ConvertNumberFromSystemToSystem(number, from, to));
        }
        static int DecimalToHexal(int dec)
        {
            int result = 0;
            int factor = 1;
            while (dec != 0)
            {
                int digit = dec % 6;
                dec /= 6;
                result += factor * digit;
                factor *= 10;
            }
            return result;
        }

        static int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
        {
            int result = 0;
            result = OtherToDecimal(number, fromSystem);
            result = DecimalToOther(result, toSystem);
            return result;
        }

        static int DecimalToOther(int dec, int system)
        {
            int result = 0;
            int factor = 1;
            while (dec != 0)
            {
                int digit = dec % system;
                dec /= system;
                result += factor * digit;
                factor *= 10;
            }
            return result;
        }

        static int OtherToDecimal(int other, int system)
        {
            int result = 0;
            int factor = 1;
            while (other != 0)
            {
                int digit = other % 10;
                other /= 10;
                result += factor * digit;
                factor *= system;
            }
            return result;
        }
    }
}
