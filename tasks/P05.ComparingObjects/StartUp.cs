using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var people = new List<Person>();
            while (command != "END")
            {
                var personInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var town = personInfo[2];
                var newPerson = new Person(name, age, town);
                people.Add(newPerson);

                command = Console.ReadLine();
            }
            int vipNumber = int.Parse(Console.ReadLine());
            var vipPerson = new Person();
            if (vipNumber > 0 || vipNumber <= people.Count)
            {
                vipPerson = people[vipNumber - 1];
                
            }
            var matches = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(vipPerson) == 0)
                {
                    matches++;
                }               
            }
            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            } else
            Console.WriteLine($"{matches} {people.Count - matches} {people.Count + 1}");
            
        }
    }
}
