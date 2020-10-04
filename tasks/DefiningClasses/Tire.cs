using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
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
