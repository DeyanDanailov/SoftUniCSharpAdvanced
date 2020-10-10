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
            var list = new List<Box<IComparable>>();
            //var box = new Box<IComparable>(null);
            for (int i = 0; i < n; i++)
            {
                list.Add(new Box<IComparable>(Console.ReadLine()));
                //Console.WriteLine(box);
            }
            //var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //var index1 = indexes[0];
            //var index2 = indexes[1];
            //list = box.SwapElements(list, index1, index2).ToList();
            var toCompare = new Box<IComparable>(Console.ReadLine());
            int result = list.Where(item => item.IsBigger(toCompare) == true).Count();
            Console.WriteLine(result);
            //var cnt = 0;
            //foreach (var item in list)
            //{
            //    if (item.IsBigger(toCompare))
            //    {
            //        cnt++;
            //    }
            //}
            //Console.WriteLine(cnt);
        }
    }
}
