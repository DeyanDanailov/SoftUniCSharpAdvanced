using System;

namespace NFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(NFactorial(n));
        }
        private static int NFactorial(int n)
        {
            if (n ==1)
            {
                return 1;
            }
            var current = n * NFactorial(n - 1);
            return current;
        }
    }
}
