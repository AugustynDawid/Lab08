using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<long> result = new HashSet<long>();
            Object locker = new Object();
            bool working = true;
            int counter = 0;

            Thread thread1 = new Thread(() =>
            {
                long i = 0;
                while(working)
                {
                    if (IsPrime(i))
                    {
                        lock(locker)
                        {
                            result.Add(i);
                            counter++;
                        }
                    }
                    i += 4;
                }

            });

            Thread thread2 = new Thread(() =>
            {
                long i = 1;
                while (working)
                {
                    if (IsPrime(i))
                    {
                        lock (locker)
                        {
                            result.Add(i);
                            counter++;
                        }
                    }
                    i += 4;
                }

            });

            Thread thread3 = new Thread(() =>
            {
                long i = 2;
                while (working)
                {
                    if (IsPrime(i))
                    {
                        lock (locker)
                        {
                            result.Add(i);
                            counter++;
                        }
                    }
                    i += 4;
                }

            });

            Thread thread4 = new Thread(() =>
            {
                long i = 3;
                while (working)
                {
                    if (IsPrime(i))
                    {
                        lock (locker)
                        {
                            result.Add(i);
                            counter++;
                        }
                    }
                    i += 4;
                }

            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            Thread.Sleep(10000);
            working = false;

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine($"Result = {result.Count}");


        }

  

        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
