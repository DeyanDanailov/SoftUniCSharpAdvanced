using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {



        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        public Car()
        {

        }
        public Car(string model, double fuelAmount, double consumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = consumption;
            this.TravelledDistance = 0.0;
        }

        public Car CollectCarInfo(string info)
        {
            var carInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var model = carInfo[0];
            var fuelAmount = double.Parse(carInfo[1]);
            var consumption = double.Parse(carInfo[2]);
            var currentCar = new Car(model, fuelAmount, consumption);
            return currentCar;
        }
        public void DriveCar(string command, List<Car> cars)
        {
            var carInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var model = carInfo[1];
            var distance = double.Parse(carInfo[2]);
            foreach (var car in cars)
            {
                if (car.Model == model)
                {
                    if (car.FuelAmount >= car.FuelConsumptionPerKilometer * distance)
                    {
                        car.TravelledDistance += distance;
                        car.FuelAmount -= car.FuelConsumptionPerKilometer * distance;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                    break;
                }
            }
        }
        public void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }

    }
}
