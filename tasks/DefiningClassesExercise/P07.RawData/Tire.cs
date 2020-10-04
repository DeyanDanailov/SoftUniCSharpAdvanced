using System;
using System.Collections.Generic;
using System.Text;

namespace P07.RawData
{
    public class Tire
    {
        public int Age { get; set; }
        public double Pressure { get; set; }
        public Tire()
        {

        }
        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}
