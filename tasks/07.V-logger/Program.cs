using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.V_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var allVloggers = new Dictionary<string, Vlogger>();
            while (input != "Statistics")
            {
                var vloggerInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var currentName = vloggerInfo[0];
                var action = vloggerInfo[1];

                if (action == "joined")
                {
                    if (allVloggers.ContainsKey(currentName))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        allVloggers.Add(currentName, new Vlogger());
                        allVloggers[currentName].followers = new List<string>();
                        allVloggers[currentName].following = new List<string>();
                    }
                }
                else if (action == "followed")
                {
                    var followedVlogger = vloggerInfo[2];
                    if (allVloggers.ContainsKey(currentName) &&
                        allVloggers.ContainsKey(followedVlogger) &&
                        currentName != followedVlogger &&
                        !allVloggers[followedVlogger].followers.Contains(currentName))
                    {
                        allVloggers[followedVlogger].followers.Add(currentName);
                        allVloggers[followedVlogger].followers = allVloggers[followedVlogger].followers.OrderBy(x => x).ToList();
                        allVloggers[currentName].following.Add(followedVlogger);
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {allVloggers.Count} vloggers in its logs.");
            allVloggers = allVloggers.OrderByDescending(x => x.Value.followers.Count)
                .ThenBy(x => x.Value.following.Count)
                .ThenBy(x => x.Value.followers)
                .ToDictionary(a => a.Key, b => b.Value);
            var counter = 1;

            foreach (var vlogger in allVloggers)
            {



                if (counter == 1 )
                {
                    if (vlogger.Value.followers.Count > 0)
                    {


                        Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");

                        foreach (var follower in vlogger.Value.followers)
                        {
                            Console.WriteLine($"*  {follower}");
                        }
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");
                }

                counter++;


            }
        }
    }
    public class Vlogger
    {
        public List<string> followers { get; set; }
        public List<string> following { get; set; }
    }
}
