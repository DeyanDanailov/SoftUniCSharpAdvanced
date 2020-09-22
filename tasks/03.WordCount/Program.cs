using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using var readerOfWords = new StreamReader("words.txt");
            var currentWords = readerOfWords.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            
            using var readerOfText = new StreamReader("text.txt");
            var line = readerOfText.ReadLine();
            var currentWordsOfText = new List<string>();
            var result = new Dictionary<string, int>();
            while (line != null)
            {
                currentWordsOfText = Regex.Split(line, @"[\s+,.?!-]+", RegexOptions.IgnoreCase,
                                    TimeSpan.FromMilliseconds(500)).ToList();
                for (int i = 0; i < currentWordsOfText.Count; i++)
                {
                    var currentWord = currentWordsOfText[i].ToLower();
                    if (currentWords.Contains(currentWord))
                    {
                        if (!result.ContainsKey(currentWord))
                        {
                            result[currentWord] = 0;
                            result[currentWord]++;
                        }
                        else
                        {
                            result[currentWord]++;
                        }
                    }
                }
                line = readerOfText.ReadLine();
            }
            
           
            
            result = result.OrderByDescending(x => x.Value).ToDictionary(a => a.Key, b => b.Value);
            using var writer = new StreamWriter("output.txt", true);
            foreach (var word in result)
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
                writer.Flush();
            }
        }
    }
}
