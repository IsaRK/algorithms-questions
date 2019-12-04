using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms
{
    public static class OtherQuestions
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

        public static void fizzBuzz(int n)
        {
            for (var i = 0; i< n; i++)
            {
                bool isMultipleOf3 = i % 3 == 0;
                bool isMultipleOf5 = i % 5 == 0;

                string result = "";

                if (isMultipleOf3)
                {
                    result += "Fizz";
                }

                if (isMultipleOf5)
                {
                    result += "Buzz";
                }

                if (!isMultipleOf3 && !isMultipleOf5)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
        }

        public static string betterCompression(string s)
        {
            var result = new SortedDictionary<char, int>();
            var index = 0;

            while(index < s.Length)
            {
                var carac = s[index];
                var frequency = new StringBuilder();

                index += 1;

                while(index < s.Length && Char.IsDigit(s[index]))
                {
                    frequency.Append(s[index]);
                    index++;
                }

                var frequencyString = frequency.ToString();
                if (String.IsNullOrEmpty(frequencyString))
                {
                    throw new Exception("No frequency attached to caracter");
                }

                //Add carac and frequency in our result dictionary
                if (result.ContainsKey(carac))
                {
                    result[carac] += Int32.Parse(frequencyString);
                }
                else
                {
                    result.Add(carac, Int32.Parse(frequencyString));
                }
            }

            return String.Join(null, result.Select(kvp => kvp.Key.ToString() + kvp.Value));
        }

        public static int countPerms(int n)
        {
        ulong totalNb = 0;
        var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        foreach (var carac in vowels)
        {
            countPermHelper(n, 1, carac, ref totalNb);
        }

        return (int)(totalNb % (Math.Pow(10, 9) + 7));
    }

    private static void countPermHelper(int n, int currentNbChar, char previousChar, ref ulong totalNb)
    {
        if (currentNbChar == n)
        {
            totalNb += 1;
            return;
        }

        switch(previousChar)
        {
            case 'a':
                countPermHelper(n, currentNbChar + 1, 'e', ref totalNb);
                break;
            case 'e':
                countPermHelper(n, currentNbChar + 1, 'a', ref totalNb);
                countPermHelper(n, currentNbChar + 1, 'i', ref totalNb);
                break;
            case 'i':
                countPermHelper(n, currentNbChar + 1, 'a', ref totalNb);
                countPermHelper(n, currentNbChar + 1, 'e', ref totalNb);
                countPermHelper(n, currentNbChar + 1, 'o', ref totalNb);
                countPermHelper(n, currentNbChar + 1, 'u', ref totalNb);
                break;
            case 'o':
                countPermHelper(n, currentNbChar + 1, 'i', ref totalNb);
                countPermHelper(n, currentNbChar + 1, 'u', ref totalNb);
                break;
            case 'u':
                countPermHelper(n, currentNbChar + 1, 'a', ref totalNb);
                break;
            default:
                throw new Exception("Previous char not handled");
        }
    }

        public static void IsoGrad()
        {
            var premiereLigne = Console.ReadLine();
            var premiereLigneStr = premiereLigne.Split(' ');
            var nbPierres = int.Parse(premiereLigneStr[0]);
            var nbPoudre = int.Parse(premiereLigneStr[1]);
            var capacite = int.Parse(premiereLigneStr[2]);

            var pierres = new List<List<int>>();
            for(var i = 0; i< nbPierres; i++)
            {
                var line = Console.ReadLine();
                var lineStr = line.Split(' ');
                var valeur = int.Parse(lineStr[0]);
                var poids = int.Parse(lineStr[1]);
                pierres.Add(new List<int> { valeur, poids });
            }

            var poudre = new List<List<int>>();
            for (var i = 0; i < nbPoudre; i++)
            {
                var line = Console.ReadLine();
                var lineStr = line.Split(' ');
                var valeurAuG = int.Parse(lineStr[0]);
                var gramme = int.Parse(lineStr[1]);
                poudre.Add(new List<int> { valeurAuG, gramme });
            }

            Console.WriteLine(PoidMax(pierres, poudre, capacite).ToString());

            // Vous pouvez aussi effectuer votre traitement ici après avoir lu toutes les données 
        }

        public static int PoidMax(List<List<int>> pierres, List<List<int>> poudres, int capacite)
        //KnapSack(int capacity, int[] weight, int[] value, int itemsCount)
        {
            var nbTotalItems = pierres.Count;

            for(var i = 0; i < poudres.Count; i++)
            {
                nbTotalItems = nbTotalItems + poudres[i][1];
            }

            var poids = new int[nbTotalItems];
            var valeur = new int[nbTotalItems];

            for(var i = 0; i < pierres.Count; i++)
            {
                poids[i] = pierres[i][1];
                valeur[i] = pierres[i][0];
            }

            var currentIndex = pierres.Count - 1;
            foreach(var poudre in poudres)
            {
                for(var j = 1; j <= poudre[1]; j++)
                {
                    poids[currentIndex] = j;
                    valeur[currentIndex] = j * poudre[0];
                    currentIndex++;
                }
            }

            //Knapsack classique
            int[,] dp = new int[poids.Count() + 1, capacite + 1];

            //for 0 items total value is zero
            for (int i = 0; i <= capacite; i++)
            {
                dp[0, i] = 0;
            }
            //for 0 weight total value is zero
            for (int i = 0; i <= poids.Count(); i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 0; i <= poids.Count(); i++)
            {
                for (int w = 0; w <= capacite; w++)
                {
                    if (poids[i] <= w)
                    {
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i, w - poids[i]] + valeur[i]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[poids.Count(), capacite];
        }

        public static string GetCablesValues(List<List<int>> input, int nbCables)
        {
            if (nbCables >= input.Count)
            {
                var directresult = new StringBuilder();
                for(var i = 1; i <= input.Count; i++)
                {
                    directresult.Append(i.ToString());
                    directresult.Append(" ");
                }
                return directresult.ToString().Trim();
            }

            var result = new StringBuilder();
            var cables = new List<int>[nbCables];

            foreach(var intervention in input)
            {
                var found = false;
                for(var i = 0; i < cables.Length; i++)
                {
                    if (cables[i] == null || cables[i].Count == 0)
                    {
                        cables[i] = new List<int> { intervention[0], intervention[1] };
                        if (result.Length == 0)
                        {
                            result.Append((i + 1).ToString());
                        }
                        else
                        {
                            result.Append(" ");
                            result.Append((i + 1).ToString());
                        }
                        
                        found = true;
                        break;
                    }
                    else if ((intervention[1] < cables[i][0] && intervention[1] < cables[i][1]) ||
                        (intervention[0] >= cables[i][1] && intervention[1] >= cables[i][1]))
                    {
                        //On prend la place de ce cable
                        if (result.Length == 0)
                        {
                            result.Append((i + 1).ToString());
                        }
                        else
                        {
                            result.Append(" ");
                            result.Append((i + 1).ToString());
                        }
                        cables[i] = intervention;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    return "pas possible";
                }
            }

            return result.ToString();
        }

    }

    
}
