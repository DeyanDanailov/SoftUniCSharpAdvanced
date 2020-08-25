using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var yellowLightDuration = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var carsWaiting = new Queue<string>();
            var carsPassedCounter = 0;
            while (input != "END")
            {
                if (input == "green")
                {
                    if (carsWaiting.Any())
                    {
                        var currentGreenLight = greenLightDuration;
                        while (currentGreenLight>0)
                        {
                            if (carsWaiting.Any())
                            {
                                var currentCar = carsWaiting.Dequeue();
                                if (currentCar.Length <= currentGreenLight)
                                {
                                    carsPassedCounter++;
                                    currentGreenLight -= currentCar.Length;
                                }
                                else
                                {
                                    var symbolsLeft = currentCar.Length - currentGreenLight;
                                    if (symbolsLeft <= yellowLightDuration)
                                    {
                                        carsPassedCounter++;
                                        currentGreenLight = 0;
                                    }
                                    else
                                    {
                                        var hitSymbol = currentCar[currentCar.Length + yellowLightDuration - symbolsLeft];
                                        Console.WriteLine("A crash happened!");
                                        Console.WriteLine($"{currentCar} was hit at {hitSymbol}.");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        
                    }
                }
                else
                {
                    carsWaiting.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedCounter} total cars passed the crossroads.");
        }
    }
}
