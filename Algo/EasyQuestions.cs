using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public static class EasyQuestions
    {
        //https://leetcode.com/problems/group-anagrams/
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new Dictionary<string, List<string>>();

            foreach(var s in strs)
            {
                var sSorted = new List<char>();
                foreach (var c in s) sSorted.Add(c);
                sSorted.Sort();

                var finalS = String.Join("", sSorted);
                if (result.ContainsKey(finalS))
                {
                    result[finalS].Add(s);
                }
                else
                {
                    result.Add(finalS, new List<string> { s});
                }
            }

            var lResult = new List<IList<string>>();
            foreach(var l in result.Values)
            {
                lResult.Add(l);
            }

            return lResult;
        }

        //https://leetcode.com/problems/two-sum/
        public static int[] TwoSum(int[] nums, int target)
        {
            var dico = new Dictionary<int, int>();

            for(var i = 0; i < nums.Length; i++)
            {
                var opposite = target - nums[i];
                if (dico.ContainsKey(opposite))
                {
                    return new int[] {i,  dico[opposite]};
                }

                if (!dico.ContainsKey(nums[i]))
                {
                    dico.Add(nums[i], i);
                }
                
            }

            return null;
        }

        //https://leetcode.com/problems/climbing-stairs
        public static int ClimbStairs(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;

            var dp = new int[n+1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;

            for(var i = 3; i < n + 1; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }
    }
}
