using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            var command = Console.ReadLine();
            
            while (songs.Any())
            {
                var actions = command.Split();
                if (actions[0] == "Play")
                {
                    songs.Dequeue();
                    if (songs.Count==0)
                    {
                       Console.WriteLine("No more songs!");
                        return;
                    }
                }
                else if (actions[0] == "Add")
                {
                    Match match = Regex.Match(command, @"Add (?<song>.+)");
                    var song = match.Groups["song"].Value;
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                        command = Console.ReadLine();
                        continue;
                    }
                    
                }
                else if (actions[0] == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
                command = Console.ReadLine();
            }
            
        }
    }
}
