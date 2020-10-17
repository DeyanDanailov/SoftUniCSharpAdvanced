using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
     public class Stack<T> : IEnumerable<T>
    {
        public Stack()
        {
            this.Items = new T[0];
        }
        
        public T[] Items { get; private set; }
        public void Push(T[] itemsToPush)
        {
            var newItems = new T[this.Items.Length + itemsToPush.Length];
            for (int i = 0; i < this.Items.Length; i++)
            {
                newItems[i] = this.Items[i];
            }
            for (int j = 0; j < itemsToPush.Length; j++)
            {
                newItems[this.Items.Length + j] = itemsToPush[j];
            }
            this.Items = newItems;
        }
        public void Pop()
        {
            if (this.Items.Length>0)
            {
                var itemToPop = this.Items[this.Items.Length - 1];
                var newItems = new T[this.Items.Length - 1];
                for (int i = 0; i < newItems.Length; i++)
                {
                    newItems[i] = this.Items[i];
                }
                this.Items = newItems;
            }
            else
            {
                Console.WriteLine("No elements");
            }
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Items.Length -1; i >= 0; i--)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
