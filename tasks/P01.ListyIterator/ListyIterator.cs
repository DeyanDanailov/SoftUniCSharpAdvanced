

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(params T[] items)
        {
            this.Items = items.ToList();
            this.CurrentIndex = 0;
        }
        public List <T> Items { get; set; }
        public int CurrentIndex { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.Items)
            {
                yield return element;
            }
        }

        public bool HasNext()
        {
            if (this.CurrentIndex < this.Items.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Move()
        {
            if (HasNext())
            {
                this.CurrentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print()
        {
            if (this.Items.Count>0)
            {
                Console.WriteLine(this.Items[CurrentIndex]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
        public void PrintAll()
        {
            if (this.Items.Count>0)
            {
                Console.WriteLine(String.Join(" ", this.Items));
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }
}
