using System;
using System.Collections.Generic;
using System.Text;

namespace GFGTests
{
    public static class QuestionsFabien
    {
        //Faire une stack à partir de queues
        public class StackFromQueue
        {
            public Queue<int> queue = new Queue<int>();

            public void Push(int i)
            {
                queue.Enqueue(i);
            }

            public int Pop()
            {
                var newQueue = new Queue<int>();
                while (queue.Count > 1)
                {
                    newQueue.Enqueue(queue.Dequeue());
                }
                var result = queue.Dequeue();
                queue = newQueue;
                return result;
            }
        }

        //https://leetcode.com/problems/fibonacci-number/
        //Fibonacci Iteratif
        public static int Fib(int N)
        {
            var a = 1;
            var b = 1;
            var c = 0;

            for (var i = 3; i <= N; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }

        //Fibonacci Recursif
        public static int FibRec(int N)
        {
            var cache = new Dictionary<int, int>();
            cache[0] = 0;
            cache[1] = 1;

            return FibRecImpl(N, cache);
        }

        private static int FibRecImpl(int n, Dictionary<int, int> cache)
        {
            if (cache.ContainsKey(n)) return cache[n];

            return FibRecImpl(n - 1, cache) + FibRecImpl(n - 2, cache);
        }

        public static int[] HistoriqueMarche(int[] arr)
        {
            var maxProfit = int.MinValue;
            var maxProfitInfo = new int[3];

            var minValue = int.MaxValue;

            var minIndex = 0;

            for(var i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
                else
                {
                    var currentProfit = arr[i] - minValue;

                    if (currentProfit > maxProfit)
                    {
                        maxProfit = currentProfit;
                        maxProfitInfo = new int[] { minIndex, i, maxProfit };
                    }
                }
            }

            return maxProfitInfo;
        }
    }
}
