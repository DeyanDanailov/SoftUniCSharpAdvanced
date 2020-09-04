using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var allCars = new HashSet<string>();
            while (input != "END")
            {
                var carInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var action = carInfo[0];
                var carNumber = carInfo[1];
                if (action == "IN")
                {
                    allCars.Add(carNumber);
                }
                else if (action == "OUT")
                {
                    allCars.Remove(carNumber);
                }
                input = Console.ReadLine();
            }
            if (allCars.Count >0)
            {
                Console.WriteLine(String.Join(Environment.NewLine, allCars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
