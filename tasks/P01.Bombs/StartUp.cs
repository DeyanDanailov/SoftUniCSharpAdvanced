using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bombEffects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var bombCasings = new Stack<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));
            var daturaBombsCnt = 0;
            var cherryBombsCnt = 0;
            var smokeBombsCnt = 0;
            while (true)
            {
                if (bombEffects.Count <=0 || bombCasings.Count <= 0)
                {
                    Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                    break;
                }
    
                var currentBombEffect = bombEffects.Peek();
                var currentBombCasing = bombCasings.Pop();
                var currentBomb = currentBombEffect + currentBombCasing;
                switch (currentBomb)
                {
                    case 40:
                        daturaBombsCnt++;
                        bombEffects.Dequeue();
                        break;
                    case 60:
                        cherryBombsCnt++;
                        bombEffects.Dequeue();
                        break;
                    case 120:
                        smokeBombsCnt++;
                        bombEffects.Dequeue();
                        break;
                    default:
                        currentBombCasing -= 5;
                        if (currentBombCasing >= 0)
                        {
                            bombCasings.Push(currentBombCasing);
                        }
                        break;
                }

                if (daturaBombsCnt >= 3 && cherryBombsCnt >= 3 && smokeBombsCnt >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    break;
                }

            }
            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: { String.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: { String.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {cherryBombsCnt}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCnt}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombsCnt}");
        }
    }
}
