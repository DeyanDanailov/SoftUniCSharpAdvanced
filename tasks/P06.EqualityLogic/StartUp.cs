using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split().ToArray();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                var person = new Person(name, age);

                sortedSet.Add(person);
                hashSet.Add(person);               
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
