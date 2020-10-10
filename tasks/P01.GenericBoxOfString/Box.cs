using System;
using System.Collections.Generic;
using System.Text;

namespace P01.GenericBoxOfString
{
    public class Box<T>
        where T : IComparable
    {
        private T value;
        public Box(T value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return $"{this.value.GetType()}: {this.value}";
        }
        public List<Box<T>> SwapElements(List<Box<T>> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            return list;
        }
        public bool IsBigger( Box<T> toCompare)
        {
            var result = this.value.CompareTo(toCompare.value);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
}
