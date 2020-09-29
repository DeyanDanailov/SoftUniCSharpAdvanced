using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var partyPeople = people.ToList();
            var command = Console.ReadLine();
            while (command != "Party!")
            {
                var info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var action = info[0];
                var startOrEndOrLength = info[1];
                var toCompare = info[2];
                var lengthOfString = toCompare.Length;
                var startsWith = new Predicate<string>(a => a.Substring(0, lengthOfString) == toCompare);
                var endsWith = new Predicate<string>(a => a.Substring(a.Length - lengthOfString, lengthOfString) == toCompare);
                var length = new Predicate<string>(a => a.Length == int.Parse(toCompare));
                DoubleOrRemove(people, partyPeople, action, startOrEndOrLength, startsWith, endsWith, length);
                people = partyPeople.ToList();
                command = Console.ReadLine();
            }
            if (partyPeople.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{String.Join(", ", partyPeople)} are going to the party!");
            }
        }

        private static void DoubleOrRemove(List<string> people, List<string> partyPeople, string action, string startOrEndOrLength, Predicate<string> startsWith, Predicate<string> endsWith, Predicate<string> length)
        {
            if (startOrEndOrLength == "StartsWith" && people.Count >0)
            {
                foreach (var person in people)
                {
                    if (startsWith(person))
                    {
                        if (action == "Double")
                        {
                            partyPeople.Add(person);
                        }
                        else if (action == "Remove")
                        {
                            partyPeople.Remove(person);
                        }
                        
                    }
                }
            }
            else if (startOrEndOrLength == "EndsWith" && people.Count > 0)
            {
                foreach (var person in people)
                {
                    if (endsWith(person))
                    {
                        if (action == "Double")
                        {
                            partyPeople.Add(person);
                        }
                        else if (action == "Remove")
                        {
                            partyPeople.Remove(person);
                        }
                    }
                }
            }
            else if (startOrEndOrLength == "Length" && people.Count > 0)
            {
                foreach (var person in people)
                {
                    if (length(person))
                    {
                        if (action == "Double")
                        {
                            partyPeople.Add(person);
                        }
                        else if (action == "Remove")
                        {
                            partyPeople.Remove(person);
                        }
                    }
                }
            }
        }
    }
}
