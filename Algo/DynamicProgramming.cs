using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithms
{
    public class DynamicProgramming
    {
        //https://practice.geeksforgeeks.org/problems/coin-change/0
        //public static int CoinChangeImpl(int n, int[] s)
        //{
        //    var result = 0;

        //    if (n == 0) return 1;

        //    foreach (var i in s)
        //    {
        //        if (n - i >= 0)
        //        {
        //            result += CoinChangeImpl(n - i, s);
        //        }
        //    }
        //    return result;
        //}

        public static int CoinChangeImpl(int n, int[] s)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = s[i]; j <= n; j++)
                {
                    dp[j] += dp[j - s[i]];
                }
            }

            return dp[n];
        }

        ////https://leetcode.com/problems/word-break/
        //public static bool WordBreak(string s, IList<string> wordDict)
        //{
        //    int maxLenght = 0;
        //    int minLenght = int.MaxValue;
        //    HashSet<string> words = new HashSet<string>();
        //    foreach (var item in wordDict)
        //    {
        //        words.Add(item);
        //        maxLenght = Math.Max(maxLenght, item.Length);
        //        minLenght = Math.Min(minLenght, item.Length);
        //    }

        //    bool[] dp = new bool[s.Length + 1];
        //    dp[0] = true; // empty string

        //    for (int i = 1; i <= s.Length; i++)
        //    {
        //        for (int j = i - minLenght; j >= 0 && i - j <= maxLenght; j--)
        //        {
        //            dp[i] = dp[j] && words.Contains(s.Substring(j, i - j));
        //            if (dp[i]) break;
        //        }
        //    }
        //    return dp[dp.Length - 1];
        //}

        //https://leetcode.com/problems/word-break/
        //My way
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> words = new HashSet<string>();
            foreach (var item in wordDict)
            {
                words.Add(item);
            }

            var dico = new Dictionary<string, bool>() { };

            return WordBreakRec(s, words, dico);
        }

        public static bool WordBreakRec(string s, HashSet<string> words, Dictionary<string, bool> dico)
        {
            if (s.Length == 0) return true;

            if (dico.ContainsKey(s)) return dico[s];

            for (var i = 1; i <= s.Length; i++)
            {
                var newS = s.Substring(i);
                if (words.Contains(s.Substring(0, i)) && WordBreakRec(newS, words, dico))
                {
                    dico.Add(newS, true);
                    return true;
                }
            }

            dico.Add(s, false);

            return false;
        }

        //https://leetcode.com/problems/longest-palindromic-substring/
        public static string LongestPalindrome(string s)
        {
            int maxLength = 0;
            int maxStart = 0;

            void CheckPalindrome(int left, int right)
            {
                while (left >= 0 && right < s.Length)
                {
                    if (s[left] != s[right])
                    {
                        break;
                    }

                    int length = right - left + 1;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        maxStart = left;
                    }
                    left--;
                    right++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                CheckPalindrome(i, i);
                CheckPalindrome(i, i + 1);
            }

            return s.Substring(maxStart, maxLength);
        }

        //https://leetcode.com/problems/maximum-subarray/
        //Kadane Algorithm
        //https://leetcode.com/problems/maximum-subarray/discuss/414582/Java-Solutions-with-3-algorithms%3A-Greedy-DP-and-Divide-and-Conquer
        public static int MaxSubArray(int[] nums)
        {
            var dp = new int[nums.Length];
            dp[0] = Math.Max(nums[0], 0);

            for (var i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], 0);
            }

            if (dp.All(x => x == 0)) return nums.Max();

                return dp.Max();
        }

        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public static int MaxProfit(int[] prices)
        {
            if (prices.Count() == 0) return 0;

            var minPrice = int.MaxValue;
            var maxProfit = int.MinValue;

            foreach(var i in prices)
            {
                minPrice = Math.Min(minPrice, i);
                var profit = i - minPrice;
                maxProfit = Math.Max(maxProfit, profit);
            }

            return maxProfit;
        }

        //https://leetcode.com/problems/maximum-product-subarray/
        //Solution : https://www.youtube.com/watch?v=-rUBh45rugs
        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var n = nums.Length;
            var dpMax = new int[n+1];
            var dpMin = new int[n + 1];

            dpMax[0] = 1;
            dpMin[0] = 1;

            for (var i = 1; i <= n; i++)
            {
                dpMax[i] = Math.Max(Math.Max(nums[i - 1] * dpMax[i - 1], nums[i - 1] * dpMin[i - 1]), nums[i-1]);
                dpMin[i] = Math.Min(Math.Min(nums[i - 1] * dpMax[i - 1], nums[i - 1] * dpMin[i - 1]), nums[i - 1]);
            }

            return dpMax.Skip(1).Max();
        }

        //https://leetcode.com/problems/unique-paths/
        public static int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];

            //Init
            for(var i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (var i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }

            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }

        //https://leetcode.com/problems/triangle/
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            var dp = new int[triangle.Count + 1][];

            for (var i = 0; i < triangle.Count + 1; i++)
            {
                dp[i] = new int[i + 1];
            }

            for (var i = 0; i < triangle.Count + 1; i++)
            {
                dp[triangle.Count][i] = 0;
            }

            for(var i = triangle.Count - 1; i >= 0; i--)
            {
                for(var j = 0; j < triangle[i].Count; j++)
                {
                    dp[i][j] = Math.Min(triangle[i][j] + dp[i + 1][j], triangle[i][j] + dp[i + 1][j + 1]);
                }
            }

            return dp[0][0];
        }

        //https://leetcode.com/problems/maximum-length-of-pair-chain/
        public static int FindLongestChain(int[][] pairs)
        {
            var dicoByEnd = new Dictionary<int, List<int[]>>();
            var sortedEnds = new SortedSet<int>();

            for(var i = 0; i < pairs.Length; i++)
            {
                sortedEnds.Add(pairs[i][1]);

                if (dicoByEnd.ContainsKey(pairs[i][1]))
                {
                    dicoByEnd[pairs[i][1]].Add(pairs[i]);
                }
                else
                {
                    dicoByEnd.Add(pairs[i][1], new List<int[]> { pairs[i] });
                }
            }

            var result = 0;
            var lastMin = int.MinValue;

            foreach(var end in sortedEnds)
            {
                foreach(var min in dicoByEnd[end])
                {
                    if (min[0] > lastMin)
                    {
                        result++;
                        lastMin = end;
                        break;
                    } 
                }
            }

            return result;
        }

        public static bool CanJump(int[] nums)
        {
            if (nums.Length <= 1) return true;

            var dp = new HashSet<int>() { 0 };

            for(var i = 0; i < nums.Length; i++)
            {
                if (dp.Contains(i))
                {
                    for (var j = 1; j <= nums[i]; j++)
                    {
                        var accessibleIndex = i + j;
                        if (accessibleIndex == nums.Length - 1)
                        {
                            return true;
                        }

                        dp.Add(i + j);
                    }
                } 
            }

            return false;
        }

        public static int CoinChange(int[] coins, int amount)
        {
            if (amount < 1) return 0;

            return CoinChangeRec(coins, amount, new int[amount]);
        }

        public static int CoinChangeRec(int[] coins, int remaining, int[] cache)
        {
            if (remaining < 0) return -1;

            if (remaining == 0)
            {
                return 0;
            }

            if (cache[remaining - 1] != 0) return cache[remaining - 1];

            int min = int.MaxValue;

            foreach(var coin in coins)
            {
                int res = CoinChangeRec(coins, remaining - coin, cache);
                if ((res >= 0) && res < min)
                {
                    min = 1+ res;
                }
            }
            cache[remaining - 1] = (min == int.MaxValue) ? -1 : min;

            return cache[remaining - 1];
        }

        public static int CoinChangeBottomUp(int[] coins, int amount)
        {
            if (amount < 1) return 0;

            var dp = new int[amount + 1];

            Array.Fill(dp, amount + 1);
            dp[0] = 0;

            for(var i = 1; i <= amount; i++)
            {
                for(var j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
