using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCountExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllText(@"..\..\..\words.txt").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var text = Regex.Split(File.ReadAllText(@"..\..\..\text.txt"), @"[\s+,.?!-]+", RegexOptions.IgnoreCase,
                                    TimeSpan.FromMilliseconds(500)).ToList();
            var result = new Dictionary<string, int>();
            foreach (var keyWord in words)
            {
                result[keyWord] = 0;
            }
            foreach (var word in text)
            {
                var wordToCheck = word.ToLower();
                if (result.ContainsKey(wordToCheck))
                {
                    result[wordToCheck]++;
                }
                
            }
            foreach (var item in result)
            {
                File.AppendAllText(@"..\..\..\actualResult.txt", $"{item.Key} - {item.Value}\n");
            }
            result = result.OrderByDescending(x => x.Value).ToDictionary(a => a.Key, b => b.Value);
            foreach (var item in result)
            {
                File.AppendAllText(@"..\..\..\expectedResult.txt", $"{item.Key} - {item.Value}\n");
            }
            Console.WriteLine(File.Equals(@"..\..\..\actualResult.txt", @"..\..\..\expectedResult.txt"));
        }
    }
}
