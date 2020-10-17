using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(int[] allStones)
        {
            this.AllStones = allStones;
        }
        public int[] AllStones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < AllStones.Length; i += 2)
            {
               yield return AllStones[i];
            }
            for (int j = AllStones.Length - 1; j > 0; j--)
            {
                if (j % 2 != 0)
                {
                    yield return AllStones[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
