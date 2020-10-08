using System;

namespace CustomListDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new CustomList<int>();
            list.Add(5);
            list.Add(3);
            list.Add(2);
            list.Add(1000);
            Console.WriteLine(list.Count);
            list.RemoveAt(2);
            
            Console.WriteLine(list.Count);

            Console.WriteLine(list[2]);
            //Console.WriteLine(list[3]);
            list.Insert(1, 500);
            Console.WriteLine(list[1]);
            Console.WriteLine(list.Contains(100));
            list.Swap(1, 0);
            Console.WriteLine(list[0]);

        }
    }
}
