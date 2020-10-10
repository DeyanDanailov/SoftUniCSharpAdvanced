using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> elements;
        
        public Box()
        {
            this.elements = new Stack<T>();
        }
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }
        public void Add(T element)
        {
            this.elements.Push(element);
        }
        public T Remove()
        {
            if (this.elements.Count==0)
            {
                throw new InvalidOperationException("There are no elements in the Box!");
            }
            var removed = this.elements.Peek();
            this.elements.Pop();
            return removed;
        }
        
    }
}
