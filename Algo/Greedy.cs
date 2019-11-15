using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public static class Greedy
    {
        public static int LastStoneWeight(int[] stones)
        {
            var list = stones.OfType<int>().ToList();
            list.Sort();

            while (list.Count >= 2)
            {
                if (list[list.Count - 2] == list[list.Count - 1])
                {
                    list.RemoveAt(list.Count - 1);
                    list.RemoveAt(list.Count - 1);
                }
                else if (list[list.Count - 2] < list[list.Count - 1])
                {
                    var newWeight = list[list.Count - 1] - list[list.Count - 2];
                    list.RemoveAt(list.Count - 1);
                    list.RemoveAt(list.Count - 1);

                    if (list.Count == 0)
                    {
                        list.Add(newWeight);
                    }
                    else
                    {
                        var indexToInsert = 0;
                        while(indexToInsert <= list.Count -1)
                        {
                            if (list[indexToInsert] < newWeight)
                            {
                                indexToInsert++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        list.Insert(Math.Max(0, indexToInsert), newWeight);
                    }
                }
            }

            return list.Count == 1 ? list[0] : 0;
        }
    }
}
