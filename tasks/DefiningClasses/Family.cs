using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public List<Person> People { get; set; }
        public void AddMember(List<Person> people, Person newMember)
        {
            people.Add(newMember);
        }
        public void GetOldestMember(List<Person> people)
        {
            people = people.OrderByDescending(p => p.Age).ToList();
            Console.WriteLine($"{people[0].Name} {people[0].Age}");
        }
        public void PrintOlderThan(List<Person> people, int age)
        {
            people = people.Where(p => p.Age > age).OrderBy(p => p.Name).ToList();
            foreach (var item in people)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
