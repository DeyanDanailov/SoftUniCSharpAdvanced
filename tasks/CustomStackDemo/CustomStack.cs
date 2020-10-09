using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStackDemo
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;
        private int count { get; set; }
        private T[] items { get; set; }
        public CustomStack()
        {
            this.count = 0;
            this.items = new T[initialCapacity];
        }
        public int Count {
            get
            {
                return this.count;
            }
            private set
            {
                this.Count = value;
            }
                 }
        public void Push(T element)
        {
            this.items[count] = element;
            this.count++;
            if (this.count == this.items.Length)
            {
                Resize();
            }
           
        }
        private void Resize()
        {
            var doubledItems = new T[this.count * 2];
            for (int i = 0; i < this.count; i++)
            {
                doubledItems[i] = this.items[i];
            }
            this.items = doubledItems;           
        }
        public T Pop()
        {
            if (this.count>0)
            {
                var poppedElement = this.items[this.count - 1];
                count--;
                if (this.count< this.items.Length/4)
                {
                    Decrease();
                }
                return poppedElement;
            }
            else
            {
                throw new InvalidOperationException("There are no elements to pop in the stack!");
            }
        }
        public T Peek()
        {
            if (this.count > 0)
            {
                var peekedElement = this.items[this.count - 1];
                return peekedElement;
            }
            else
            {
                throw new InvalidOperationException("There are no elements to peek in the stack!");
            }

        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }

        }
        private void Decrease()
        {
            var decreasedArr = new T[this.items.Length / 2];
            for (int i = 0; i < this.count; i++)
            {
                decreasedArr[i] = this.items[i];
            }
            this.items = decreasedArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items
                .Take(this.Count)
                .Reverse()
                .ToList()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
