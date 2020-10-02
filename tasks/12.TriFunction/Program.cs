using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string, int, bool> isBigger = (name, sumToOvercome) =>
            {
                var sum = 0;
                foreach (var letter in name)
                {
                    sum += letter;
                }
                if (sum >= sumToOvercome)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            var result = FindName(names, isBigger, n);
            Console.WriteLine(result);
        }
        public static string FindName(string[] names, Func<string, int, bool>isBigger, int n)
        {
            foreach (var name in names)
            {
                if (isBigger(name,n))
                {
                    return name;                  
                }              
            }
            return "Error";
        }
    }
}
