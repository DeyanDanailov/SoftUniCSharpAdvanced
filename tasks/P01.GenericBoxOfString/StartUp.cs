using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Box<int>>();
            var box = new Box<int>(0);
            for (int i = 0; i < n; i++)
            {
                var currentInt = int.Parse(Console.ReadLine());
                 box = new Box<int>(currentInt);
                list.Add(box);
                //Console.WriteLine(box);
            }
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index1 = indexes[0];
            var index2 = indexes[1];
            list = box.SwapElements(list, index1, index2).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, list));
        }
    }
}
