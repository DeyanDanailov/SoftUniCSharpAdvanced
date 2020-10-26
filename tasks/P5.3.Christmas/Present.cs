using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Present
    {
        public Present(string name, double weight, string gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Gender = gender;
        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Present {this.Name} ({this.Weight}) for a {this.Gender}");
            return sb.ToString().TrimEnd();
        }
    }
}
