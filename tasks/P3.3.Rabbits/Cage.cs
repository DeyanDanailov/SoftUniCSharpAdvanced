using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }
        private List<Rabbit> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            foreach (var rabbit in this.data)
            {
                if (rabbit.Name == name)
                {
                    this.data.Remove(rabbit);
                    return true;
                }
            }
            return false;
        }
        public void RemoveSpecies(string species)
        {
            this.data = this.data.Where(r => r.Species != species).ToList();
        }
        public Rabbit SellRabbit(string name)
        {
            var emptyRabbit = new Rabbit("", "");
            foreach (var rabbit in this.data)
            {
                if (rabbit.Name == name)
                {
                    rabbit.Available = false;
                    return rabbit;
                }
            }
            return emptyRabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitList = new List<Rabbit>();
            foreach (var rabbit in this.data)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    rabbitList.Add(rabbit);
                }
            }
            return rabbitList.ToArray();
        }
        public string Report()
        {
            var notSoldRabbits = this.data.Where(r=>r.Available == true).ToList();
            var sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            sb.AppendLine(String.Join(Environment.NewLine, notSoldRabbits));

            return sb.ToString().Trim();
        }
    }
}
