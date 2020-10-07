using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddFirst($"Pesho{i}");
            }
            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddLast($"Pesho{i}");
            }
            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.RemoveFirst();
            }
            Console.WriteLine(doublyLinkedList[5]);
            doublyLinkedList.ForEach(n => Console.Write(n + " "));
            doublyLinkedList.ToArray();
            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
