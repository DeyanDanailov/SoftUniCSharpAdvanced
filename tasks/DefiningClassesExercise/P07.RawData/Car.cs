using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public HashSet<Tire> Tires { get; set; }
        public Car()
        {

        }

        public Car(string model, Engine engine, Cargo cargo, HashSet<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
        public Car CollectCarInfo(string info)
        {
            var carInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var model = carInfo[0];
            var engineSpeed = int.Parse(carInfo[1]);
            var enginePower = int.Parse(carInfo[2]);
            var cargoWeight = int.Parse(carInfo[3]);
            var cargoType = carInfo[4];
            var tire1Pressure = double.Parse(carInfo[5]);
            var tire1Age = int.Parse(carInfo[6]);
            var tire2Pressure = double.Parse(carInfo[7]);
            var tire2Age = int.Parse(carInfo[8]);
            var tire3Pressure = double.Parse(carInfo[9]);
            var tire3Age = int.Parse(carInfo[10]);
            var tire4Pressure = double.Parse(carInfo[11]);
            var tire4Age = int.Parse(carInfo[12]);

            var engine = new Engine(enginePower, engineSpeed);
            var cargo = new Cargo(cargoWeight, cargoType);
            var tire1 = new Tire(tire1Age, tire1Pressure);
            var tire2 = new Tire(tire2Age, tire2Pressure);
            var tire3 = new Tire(tire3Age, tire3Pressure);
            var tire4 = new Tire(tire4Age, tire4Pressure);
            var tires = new HashSet<Tire>();
            tires.Add(tire1);
            tires.Add(tire2);
            tires.Add(tire3);
            tires.Add(tire4);
            var currentCar = new Car(model, engine, cargo, tires);
            return currentCar;
        }
        public void PrintCarsDependingOnCargoFilter(HashSet<Car> cars, string cargoFilter)
        {

            if (cargoFilter == "fragile")
            {
                cars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).ToHashSet();
            }
            else if (cargoFilter == "flamable")
            {
                cars = cars.Where(c => c.Cargo.Type == "flamable").Where(c => c.Engine.Power > 250).ToHashSet();

            }
            foreach (var item in cars)
            {
                Console.WriteLine(item.Model);
            }
        }


    }
}
