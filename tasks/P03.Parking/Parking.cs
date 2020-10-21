using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        private List<Car> data;
        //public List<Car> Data {
        //    get 
        //    { return this.data; } 
        //    set 
        //    {this.data = value; }
        //}
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public void Add(Car car)
        {
            if (this.data.Count<this.Capacity)
            {
                this.data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            foreach (var car in this.data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    this.data.Remove(car);
                    return true;
                }
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (this.data.Count>0)
            {
                this.data = this.data.OrderByDescending(c => c.Year).ToList();
                return this.data[0];
            }
            return null;            
        }
        public Car GetCar(string manufacturer, string model)
        {
            foreach (var car in this.data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}
