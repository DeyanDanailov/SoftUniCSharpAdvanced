using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            //05.task
            //string date1 = Console.ReadLine();
            //string date2 = Console.ReadLine();

            //DateModifier dateModifier = new DateModifier();

            //Console.WriteLine(dateModifier.CalculateDifference(date1, date2));


            var n = int.Parse(Console.ReadLine());
            var car = new Car();
            var allCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine();
                car = car.CollectCarInfo(info);
                allCars.Add(car);
            }
            var command = Console.ReadLine();
            while (command != "End")
            {
                car.DriveCar(command, allCars);
                command = Console.ReadLine();
            }
            car.PrintCars(allCars);

            
            
        }
    }
}
