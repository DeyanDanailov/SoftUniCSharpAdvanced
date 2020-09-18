using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            FillWardrobe(n, wardrobe);
            var clothingToSearch = Console.ReadLine().Split();
            var colorToFind = clothingToSearch[0];
            var clothingToFind = clothingToSearch[1];
            PrintWardrobe(wardrobe, colorToFind, clothingToFind);
        }

        private static void PrintWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string colorToFind, string clothingToFind)
        {
            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var clothing in item.Value)
                {
                    if (item.Key == colorToFind && clothing.Key == clothingToFind)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");
                    }
                }
            }
        }

        private static void FillWardrobe(int n, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (wardrobe.ContainsKey(info[0]))
                {
                    for (int j = 1; j < info.Length; j++)
                    {
                        if (wardrobe[info[0]].ContainsKey(info[j]))
                        {
                            wardrobe[info[0]][info[j]]++;
                        }
                        else
                        {
                            wardrobe[info[0]][info[j]] = 1;
                        }
                    }
                }
                else
                {
                    wardrobe[info[0]] = new Dictionary<string, int>();
                    for (int j = 1; j < info.Length; j++)
                    {
                        if (wardrobe[info[0]].ContainsKey(info[j]))
                        {
                            wardrobe[info[0]][info[j]]++;
                        }
                        else
                        {
                            wardrobe[info[0]][info[j]] = 1;
                        }
                    }
                }
            }
        }
    }
}
