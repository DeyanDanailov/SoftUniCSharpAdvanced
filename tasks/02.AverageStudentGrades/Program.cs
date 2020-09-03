using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var n = int.Parse(Console.ReadLine());
            var allStudents = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = input[0];
                var grade = decimal.Parse(input[1]);
                if (!allStudents.TryAdd(name, new List<decimal>() {grade}))
                {
                    allStudents[name].Add(grade);
                }
            }
            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.Key} -> {String.Join(' ',item.Value.Select(x=>x.ToString("F2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
