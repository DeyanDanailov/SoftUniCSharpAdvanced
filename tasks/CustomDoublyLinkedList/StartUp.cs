using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList();

            for (int i = 1; i <= 3; i++)
            {
                doublyLinkedList.AddFirst(i);
            }
            for (int i = 1; i <= 3; i++)
            {
                doublyLinkedList.RemoveFirst();
            }
        }
    }
}
