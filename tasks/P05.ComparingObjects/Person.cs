using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P05.ComparingObjects
{
    public class Person :IComparable<Person>
    {
        public Person()
        {

        }
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo(Person person)
        {
            if (this.Name == person.Name && 
                this.Age == person.Age && 
                this.Town == person.Town)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        
    }
}
