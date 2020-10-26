using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }
        private List<Present> data;
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            foreach (var present in this.data)
            {
                if (present.Name == name)
                {
                    this.data.Remove(present);
                    return true;
                }
            }
            return false;
        }
        public Present GetHeaviestPresent()
        {
            var heaviest = this.data.OrderByDescending(p => p.Weight).FirstOrDefault();
            return heaviest;
        }
        public Present GetPresent(string name)
        {
            foreach (var present in this.data)
            {
                if (present.Name == name)
                {
                   
                    return present;
                }
            }
            return null;
        }
        public string Report()
        {
            
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            sb.AppendLine(String.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }
    }
}
