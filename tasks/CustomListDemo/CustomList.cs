using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListDemo
{
   public class CustomList <T>
    {
        private const int InitialCapacity = 2;
        private T[] items;
        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }
        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                if (index>=this.Count || index<0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of List range!");
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of List range!");
                }
                items[index] = value;
            }
        }
        private void Resize()
        {
            T[] copy = new T[this.items.Length*2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            var item = this.items[index];
            this.Shift(index);
            
            this.Count--;
            if (this.Count < this.items.Length/4)
            {
                this.Shrink();
            }
            return item;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, T element)
        {
            this.ValidateIndex(index);
            if (index == this.Count)
            {
                this.Add(element);
            }
            else
            {
                if (this.Count == this.items.Length)
                {
                    this.Resize();
                }
                this.ShiftToRight(index);
                 this.items[index] = element;
                this.Count++;
            }

        }
        public void ValidateIndex(int index)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of list range!");
            }
        }
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(items[i].Equals(element))
                {
                    return true;                  
                }
            }
            return false;            
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
    }
}
