using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var contests = new Dictionary<string, string>();
            string command, bestPerson;
            Dictionary<string, Candidate> allCandidates;
            int bestPoints;
            input = ReceivingContests(input, contests, out command, out allCandidates, out bestPerson, out bestPoints);
            while (command != "end of submissions")
            {
                var commandInfo = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                var currentCont = commandInfo[0];
                var currentPass = commandInfo[1];
                var person = commandInfo[2];
                var points = int.Parse(commandInfo[3]);
                if (contests.ContainsKey(currentCont))
                {
                    if (contests[currentCont] == currentPass)
                    {
                        if (allCandidates.ContainsKey(person) )
                        {
                            if (allCandidates[person].contestResults.ContainsKey(currentCont))
                            {


                                if (allCandidates[person].contestResults[currentCont] < points)
                                {
                                    allCandidates[person].totalPoints -= points;
                                    allCandidates[person].contestResults[currentCont] = points;
                                    allCandidates[person].totalPoints += points;
                                    if (allCandidates[person].totalPoints > bestPoints)
                                    {
                                        bestPoints = allCandidates[person].totalPoints;
                                        bestPerson = person;
                                    }
                                }
                            }
                            else
                            {
                                allCandidates[person].contestResults.Add(currentCont, points);
                                allCandidates[person].totalPoints += points;
                                if (allCandidates[person].totalPoints > bestPoints)
                                {
                                    bestPoints = allCandidates[person].totalPoints;
                                    bestPerson = person;
                                }
                            }
                        }
                        else
                        {
                            allCandidates[person] =  new Candidate();
                            allCandidates[person].contestResults = new Dictionary<string, int>();
                            allCandidates[person].contestResults[currentCont] = points;
                            //allCandidates = allCandidates.OrderByDescending(x => x.Value.contestResults).ToDictionary(a => a.Key, b => b.Value);
                            allCandidates[person].totalPoints += points;
                            if (allCandidates[person].totalPoints > bestPoints)
                            {
                                bestPoints = allCandidates[person].totalPoints;
                                bestPerson = person;
                            }
                        }

                    }
                }
                command = Console.ReadLine();
            }
            allCandidates = allCandidates.OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            Console.WriteLine($"Best candidate is {bestPerson} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in allCandidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.contestResults.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static string ReceivingContests(string input, Dictionary<string, string> contests, out string command, out Dictionary<string, Candidate> allCandidates, out string bestPerson, out int bestPoints)
        {
            while (input != "end of contests")
            {
                var contestInfo = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                var currentContest = contestInfo[0];
                var currentPassword = contestInfo[1];
                contests[currentContest] = currentPassword;
                input = Console.ReadLine();
            }
            command = Console.ReadLine();
            allCandidates = new Dictionary<string, Candidate>();
            bestPerson = String.Empty;
            bestPoints = 0;
            return input;
        }
    }
    public class Candidate {
        public Dictionary<string, int> contestResults { get; set; }
        public int totalPoints { get; set; }
    }
}
