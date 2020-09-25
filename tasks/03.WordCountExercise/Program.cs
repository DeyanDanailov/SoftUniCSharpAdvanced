using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCountExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllText("words.txt").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var text = Regex.Split(File.ReadAllText("text.txt"), @"[\s+,.?!-]+", RegexOptions.IgnoreCase,
                                    TimeSpan.FromMilliseconds(500)).ToList();
            var result = new Dictionary<string, int>();
            foreach (var word in text)
            {
                
                if (words.Contains(word.ToLower()))
                {
                    if (!result.ContainsKey(word.ToLower()))
                    {
                        result[word.ToLower()] = 1;
                    }
                    else
                    {
                        result[word.ToLower()]++;
                    }
                }
            }
            foreach (var item in result)
            {
                File.AppendAllText("actualResult.txt", $"{item.Key} - {item.Value}\n");
            }
            result = result.OrderByDescending(x => x.Value).ToDictionary(a => a.Key, b => b.Value);
            foreach (var item in result)
            {
                File.AppendAllText("expectedResult.txt", $"{item.Key} - {item.Value}\n");
            }
            Console.WriteLine(File.Equals("actualResult.txt", "expectedResult.txt") ); 
        }
    }
}
