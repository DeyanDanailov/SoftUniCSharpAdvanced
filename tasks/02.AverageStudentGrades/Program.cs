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
            var allStudents = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = input[0];
                var grade = double.Parse(input[1]);
                if (!allStudents.TryAdd(name, new List<double>() {grade}))
                {
                    allStudents[name].Add(grade);
                }
            }
            foreach (var item in allStudents)
            {
                Console.WriteLine($"{item.Key} -> {String.Join(' ',item.Value):f2} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
