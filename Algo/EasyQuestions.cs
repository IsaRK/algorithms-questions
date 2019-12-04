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

        public static bool IsPowerOfTwo(int n)
        {
            var rem = n;

            while(rem > 0)
            {
                if (rem == 1) return true;
                if (rem % 2 != 0) return false;

                rem = Math.DivRem(rem, 2, out int reste);
            }

            return true;
        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new HashSet<int>();

            for(var i = 1; i <= nums.Length; i++)
            {
                result.Add(i);
            }

            foreach(var i in nums)
            {
                if (result.Contains(i))
                {
                    result.Remove(i);
                }
            }

            return result.ToList();
        }

        public static int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            if (nums.Length == 3) return Math.Max(nums[0] + nums[2], nums[1]);

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = nums[1];
            dp[2] = nums[2] + dp[0];

            for(var i = 3; i < nums.Length; i++)
            {
                dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
            }

            return dp.Max();
        }

        public static int Rob2(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            if (nums.Length == 3) return Math.Max(Math.Max(nums[0], nums[2]), nums[1]);

            int RobRec(int[] numsRec)
            {
                if (numsRec.Length == 0) return 0;
                if (numsRec.Length == 1) return numsRec[0];
                if (numsRec.Length == 2) return Math.Max(numsRec[0], numsRec[1]);
                if (numsRec.Length == 3) return Math.Max(numsRec[0] + numsRec[2], numsRec[1]);

                var dp = new int[numsRec.Length];
                dp[0] = numsRec[0];
                dp[1] = numsRec[1];
                dp[2] = numsRec[2] + dp[0];

                for (var i = 3; i < numsRec.Length; i++)
                {
                    dp[i] = numsRec[i] + Math.Max(dp[i - 2], dp[i - 3]);
                }

                return dp.Max();
            }

            return Math.Max(RobRec(nums.Take(nums.Length - 1).ToArray()), RobRec(nums.Skip(1).Take(nums.Length - 1).ToArray()));
        }

        //https://leetcode.com/problems/letter-case-permutation/
        public static IList<string> LetterCasePermutation(string S)
        {
            var result = new List<string>();
            var tmpResult = new char[S.Length];

            void LetterCaseRec(int index)
            {
                if (index > S.Length - 1)
                {
                    result.Add(new string(String.Join(null, tmpResult)));
                    return;
                }

                tmpResult[index] = char.Parse(S[index].ToString().ToLower());
                LetterCaseRec(index + 1);

                if (int.TryParse(tmpResult[index].ToString(), out int digit))
                {
                    return;
                }

                tmpResult[index] = char.Parse(S[index].ToString().ToUpper());
                LetterCaseRec(index + 1);
            }

            LetterCaseRec(0);

            return result;
        }

        public static int MySqrt(int x)
        {
            var decimalSqrt = Math.Sqrt(x);

            return (int)Math.Floor(decimalSqrt);
        }
    }
}
