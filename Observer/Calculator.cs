using System;

namespace Observer
{
    //bundle methods together that have the same arguments and return type
    public delegate void ReportProgressMethod(double progress);
    public class Calculator
    {
        //create event of the delegate type
        public event ReportProgressMethod ProgressMethod;

        public long CalculateNthPrime(int n)
        {
            //assign methods to the event, that will be called once the event is invoked
            ProgressMethod += WriteProgress;

            int count=0;
            long a = 2;
            while(count<n)
            {
                long b = 2;
                Boolean prime = true;
                while(b * b <= a)
                {
                    if(a % b == 0)
                    {
                        prime = false;
                        break;
                    }
                    b++;
                }
                if(prime)
                {
                    count++;
                    //every 200 iterations invoke the event
                    if(count%200 == 199)
                    {
                        ProgressMethod((double)count/(double)n);
                    }
                }
                a++;
            }
            return (--a);
        }

        public void WriteProgress(double progress)
        {
            Console.Clear();
            Console.WriteLine(progress*100 + "%");
        }
    }
}