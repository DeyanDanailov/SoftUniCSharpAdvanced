using System;
using System.Linq;

namespace P01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var creationInfo = Console.ReadLine().Split();
            var elements = new string[creationInfo.Length - 1];
            for (int i = 1; i < creationInfo.Length; i++)
            {
                elements[i - 1] = creationInfo[i];
            }
            var myIterator = new ListyIterator<string>(elements);
            var command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(myIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(myIterator.HasNext());
                        break;
                    case "Print":
                        myIterator.Print();
                        break;
                    case "PrintAll":
                        myIterator.PrintAll();
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
