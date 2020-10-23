using System;
using System.Collections.Generic;
using System.Linq;

namespace P5._1.SantaPresentFactory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var materialsBox = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));
            var magicBox = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            var dollAmount = 0;
            var trainAmount = 0;
            var bearAmount = 0;
            var bicycleAmount = 0;

            while (true)
            {
                if (materialsBox.Count <= 0 || magicBox.Count <= 0)
                {
                    break;
                }               
                var currentMaterial = materialsBox.Peek();
                while (materialsBox.Count >0 && currentMaterial == 0)
                {
                    currentMaterial = materialsBox.Pop();
                    if (materialsBox.Count == 0 )
                    {
                        break;
                    }
                    currentMaterial = materialsBox.Peek();
                }
                var currentMagic = magicBox.Peek();
                while (magicBox.Count>0 && currentMagic == 0)
                {
                    currentMagic = magicBox.Dequeue();
                    if (magicBox.Count == 0)
                    {
                        break;
                    }
                    currentMagic = magicBox.Peek();
                }
                if (materialsBox.Count == 0 || magicBox.Count == 0)
                {
                    break;
                }
                currentMagic = magicBox.Dequeue();
                var result = currentMagic * currentMaterial;
               
                if (result > 0)
                {
                    switch (result)
                    {
                        case 150:
                            dollAmount++;
                            materialsBox.Pop();
                            break;
                        case 250:
                            trainAmount++;
                            materialsBox.Pop();
                            break;
                        case 300:
                            bearAmount++;
                            materialsBox.Pop();
                            break;
                        case 400:
                            bicycleAmount++;
                            materialsBox.Pop();
                            break;
                        default:
                            currentMaterial = materialsBox.Pop();
                            currentMaterial += 15;
                            materialsBox.Push(currentMaterial);
                            break;
                    }
                }
                else if(result <= 0)
                {
                    currentMaterial = materialsBox.Pop();
                    materialsBox.Push(currentMaterial + currentMagic);
                }

            }
            if ((dollAmount >0 && trainAmount>0) || (bearAmount >0 && bicycleAmount > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materialsBox.Count > 0)
            {
                Console.WriteLine($"Materials left: {String.Join(", ", materialsBox)}");
            }
            if (magicBox.Count > 0)
            {
                Console.WriteLine($"Magic left: {String.Join(", ", magicBox)}");
            }

            if (bicycleAmount >0)
            {
                Console.WriteLine($"Bicycle: {bicycleAmount}");
            }
            if (dollAmount > 0)
            {
                Console.WriteLine($"Doll: {dollAmount}");
            }
            if (bearAmount > 0)
            {
                Console.WriteLine($"Teddy bear: {bearAmount}");
            }
            if (trainAmount > 0)
            {
                Console.WriteLine($"Wooden train: {trainAmount}");
            }
            
        }
    }
}
