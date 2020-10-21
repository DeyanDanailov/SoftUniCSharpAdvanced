using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }
        private List<Pet> data;
       
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public int Capacity { get; set; }
        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            foreach (var pet in this.data)
            {
                if (pet.Name == name )
                {
                    this.data.Remove(pet);
                    return true;
                }
            }
            return false;
        }
        public Pet GetOldestPet()
        {
            if (this.data.Count > 0)
            {
                this.data = this.data.OrderByDescending(p => p.Age).ToList();
                return this.data[0];
            }
            return null;
        }
        public Pet GetPet(string name, string owner)
        {
            foreach (var pet in this.data)
            {
                if (pet.Name == name && pet.Owner == owner)
                {
                    return pet;
                }
            }
            return null;
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString();
        }
    }
}
