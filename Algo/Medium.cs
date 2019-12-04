using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public static class Medium
    {
        //https://leetcode.com/problems/generate-parentheses/
        public static IList<string> GenerateParenthesis(int n)
        {
            void TryAddToHashSet(HashSet<string> hashSet, string s)
            {
                if (!hashSet.Contains(s))
                {
                    hashSet.Add(s);
                }
            }

            var currentLevel = 2;
            var result = new List<string>();

            var cache = new Dictionary<int, HashSet<string>>();
            cache.Add(0, new HashSet<string> { "" });
            cache.Add(1, new HashSet<string> { "()" });

            while (currentLevel <= n)
            {
                var currentLevelResult = new HashSet<string>();

                foreach (var i in cache[currentLevel - 1])
                {
                    TryAddToHashSet(currentLevelResult, "(" + i + ")");
                    TryAddToHashSet(currentLevelResult, "()" + i);
                    TryAddToHashSet(currentLevelResult, i + "()");

                    for (int j = 1; j < i.Length; j++)
                    {
                        TryAddToHashSet(currentLevelResult, i.Insert(j, "()"));
                    }
                }

                cache.Add(currentLevel, currentLevelResult);
                currentLevel++;
            }

            foreach (var i in cache[n])
            {
                result.Add(i);
            }

            return result;
        }

        //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
        public static int[] SearchRange(int[] nums, int target)
        {
            var start = 0;
            var end = nums.Length;
            int mid = end / 2;
            while(mid >= 0 && mid <= nums.Length - 1)
            {
                if (target < nums[mid])
                {
                    end = mid;
                    mid = (end + start) / 2;
                }
                else if (target > nums[mid])
                {
                    start = mid;
                    mid = (end + start) / 2;
                }
                else
                {
                    var startEnd = mid;
                    var startMid = startEnd / 2;
                    var startStart = 0;
                    bool minFound = false;

                    while(startMid >= 0 && !minFound)
                    {
                        //on cherche à quel moment ça devient strictement plus petit
                        if (target == nums[startMid])
                        {
                            startEnd = startMid;
                            startMid = (startEnd + startStart) / 2;
                        }
                        else if (target > nums[startMid])
                        {
                            if (nums[startMid + 1] == target)
                            {
                                startMid = startMid + 1;
                                minFound = true;
                            }
                            else
                            {
                                startStart = startMid;
                                startMid = (startEnd + startStart) / 2;
                            }
                        }
                    }

                    var endEnd = nums.Length - 1;
                    var endStart = mid;
                    var endMid = (endEnd + endStart) / 2;
                    
                    bool maxFound = false;

                    while (endMid <= nums.Length - 1 && !maxFound)
                    {
                        if (target == nums[endMid])
                        {
                            endStart = endMid;
                            endMid = (endEnd + endStart + 1) / 2;
                        }
                        else if (target < nums[endMid])
                        {
                            if (nums[endMid - 1] == target)
                            {
                                endMid = endMid - 1;
                                maxFound = true;
                            }
                            else
                            {
                                endEnd = endMid;
                                endMid = (endEnd + endStart) / 2;
                            }
                            
                        }
                    }

                    return new int[2] { startMid, endMid };
                }
            }

            return new int[2] { -1, -1 };
        }

        //https://leetcode.com/problems/longest-substring-without-repeating-characters/
        public static int LengthOfLongestSubstring(string s)
        {
            var set = new HashSet<char>();
            var cpt = 0;
            var max = 0;
            var indexStart = 0;

            for(var i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]))
                {
                    if (cpt > max)
                    {
                        max = cpt;
                    }

                    //Reset
                    set.Clear();
                    cpt = 0;

                    while(s[indexStart] != s[i])
                    {
                        indexStart++;
                    }

                    indexStart++;
                    for (var j = indexStart; j <= i; j++)
                    {
                        cpt++;
                        set.Add(s[j]);
                    }
                }
                else
                {
                    cpt++;
                    set.Add(s[i]);
                }
            }

            if (cpt > max)
            {
                max = cpt;
            }

            return max;
        }

        //https://leetcode.com/problems/letter-combinations-of-a-phone-number/solution/
        public static IList<string> LetterCombinations(string digits)
        {
            var dico = new Dictionary<char, string>
            {
                {'2', "abc" },
                {'3', "def" },
                {'4', "ghi" },
                {'5', "jkl" },
                {'6', "mno" },
                {'7', "pqrs" },
                {'8', "tuv" },
                {'9', "xywz" },
            };

            var results = new List<string>();
            var result = new char[digits.Length];

            void LetterCombinationsRec(int index)
            {
                foreach(var carac in dico[digits[index]])
                {
                    result[index] = carac;

                    if (index + 1 < digits.Length)
                    {
                        LetterCombinationsRec(index + 1);
                    }
                    else
                    {
                        results.Add(new string(result));
                    }
                }
            }

            if (digits.Length > 0)
            {
                LetterCombinationsRec(0);
            }

            return results;
        }

        //https://leetcode.com/problems/combination-sum/
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<IList<int>>();

            var current = 0;
            var list = new List<int>();

            void CombinationSumRec(int current, int indexStart)
            {
                if (current == target)
                {
                    result.Add(new List<int>(list));
                }
                else
                {
                    for(var i = indexStart; i < candidates.Length; ++i)
                    {
                        if (current + candidates[i] <= target)
                        {
                            list.Add(candidates[i]);
                            CombinationSumRec(current + candidates[i], i);
                            list.RemoveAt(list.Count - 1);
                        }
                    }
                }
            }

            CombinationSumRec(current, 0);

            return result;
        }

        //https://leetcode.com/problems/permutations/
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            var tmp = new Stack<int>();

            PermuteRec(result, nums.ToList(), tmp);
          
            return result;
        }

        public static void PermuteRec(List<IList<int>> result, List<int> nums, Stack<int> tmp)
        {
            if (nums.Count == 0)
            {
                result.Add(new List<int>(tmp));
            }

            for(var i = 0; i< nums.Count; i++)
            {
                var tmpInt = nums[i];
                tmp.Push(tmpInt);
                nums.RemoveAt(i);

                PermuteRec(result, nums, tmp);

                tmp.Pop();
                nums.Insert(i, tmpInt);
            }
        }

        //https://leetcode.com/problems/combinations/
        public static IList<IList<int>> Combine(int n, int k)
        {
            var result = new List<IList<int>>();

            var usedInt = new HashSet<int>();
            var tmpResult = new int[k];

            void CombineHelper(int indexK, int start)
            {
                if (indexK == k)
                {
                    result.Add(new List<int>(tmpResult));
                    return;
                }

                for(var i = start; i <= n; i++)
                {
                    if (!usedInt.Contains(i))
                    {
                        tmpResult[indexK] = i;
                        usedInt.Add(i);
                        CombineHelper(indexK + 1, i + 1);

                        usedInt.Remove(i);
                    }
                }
            }

            CombineHelper(0, 1);

            return result;
        }

        //Too tricky
        /*
        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            result.Add(new List<int>());
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                List<IList<int>> newResult = new List<IList<int>>();
                foreach (var r in result)
                {
                    List<int> nr = new List<int>(r);
                    nr.Add(nums[i]);
                    newResult.Add(nr);
                }
                result.AddRange(newResult);
            }
            return result;
        }
        */

        //More my style
        public static IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<IList<int>>();

            void SubsetsRec(int start, IList<int> oneResult)
            {
                result.Add(new List<int>(oneResult));

                for (int i = start; i < nums.Length; i++)
                {
                    oneResult.Add(nums[i]);
                    SubsetsRec(i + 1, oneResult);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }

            SubsetsRec(0, new List<int>());

            return result;
        }

        //https://leetcode.com/problems/next-permutation/
        public static void NextPermutation(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return;

            void SwapLastTwo()
            {
                var tmp = nums[nums.Length - 1];
                nums[nums.Length - 1] = nums[nums.Length - 2];
                nums[nums.Length - 2] = tmp;
            }

            void SwapWithDirectlySup(int start)
            {
                var maxDirect = int.MaxValue;
                for(var i = start; i < nums.Length; i++)
                {
                    if (nums[i] > nums[start] && nums[i] <= maxDirect)
                    {
                        maxDirect = nums[i];
                    }
                }

                var tmp = nums[start];
                var indexToSwap = Array.LastIndexOf(nums, maxDirect);
                nums[start] = nums[indexToSwap];
                nums[indexToSwap] = tmp;
            }

            void InsertInOrderFromIndex(int start)
            {
                var i = start;
                while(i < nums.Length - 1)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        var tmp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = tmp;
                    }

                    i = i + 1;
                }
            }

            var index = nums.Length - 1;
            bool hasOrdreInverse = false;
            int maxOrdreInverse = int.MinValue;

            while(index > 0)
            {
                if (hasOrdreInverse && nums[index - 1] < maxOrdreInverse)
                {
                    SwapWithDirectlySup(index - 1);
                    break;
                }

                if (nums[index] < nums[index - 1])
                {
                    hasOrdreInverse = true;
                    InsertInOrderFromIndex(index - 1);
                    maxOrdreInverse = Math.Max(maxOrdreInverse, nums[index]);

                    if (index == 1)
                    {
                        SwapWithDirectlySup(index - 1);
                        break;
                    }
                }

                index = index - 1;
            }

            if (!hasOrdreInverse)
            {
                SwapLastTwo();
            }
        }
    }
}
