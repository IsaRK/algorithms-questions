using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class RelativeSorting
    {
        //https://practice.geeksforgeeks.org/problems/relative-sorting/0
        public static int[] RelativeSortingImpl(int[] a, int[] b)
        {
            var dico = new Dictionary<int, int>() { };
            var listKeys = new List<int>();

            foreach(var i in a)
            {
                if (dico.ContainsKey(i))
                {
                    dico[i]++;
                }
                else
                {
                    dico.Add(i, 1);
                }
            }

            var result = new List<int>();

            foreach(var i in b)
            {
                for(var x = 0; x <dico[i]; x++)
                {
                    result.Add(i);
                }
                dico.Remove(i);
            }

            foreach(var i in dico.Keys)
            {
                listKeys.Add(i);
            }
            listKeys.Sort();

            foreach (var i in listKeys)
            {
                for (var x = 0; x < dico[i]; x++)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }
    }
}
