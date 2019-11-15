using GFGTests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "applepenapple", new List<string> { "apple", "pen" }, true };
            yield return new object[] { "applespenapple", new List<string> { "apple", "pen" }, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DynamicProgrammingTest
    {
        [Theory]
        [InlineData(4, new int[] { 1, 2, 3 }, 4)]
        [InlineData(3, new int[] { 1 }, 1)]
        public static void Test(int n, int[] s, int expected)
        {
            Assert.Equal(expected, DynamicProgramming.CoinChangeImpl(n,s));
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public static void TestWordBreak(string s, List<string> dico, bool expected)
        {
            Assert.Equal(expected, DynamicProgramming.WordBreak(s, dico));
        }

        [Fact]
        public static void LongestPalindromeTest()
        {
            Assert.Equal("bab", DynamicProgramming.LongestPalindrome("babad"));
        }

        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { -1, -2 }, -1)]
        public static void MaxSubArrayTest(int[] n, int expected)
        {
            Assert.Equal(expected, DynamicProgramming.MaxSubArray(n));
        }

        [Theory]
        [InlineData(new int[] { 2, 3, -2, 4 }, 6)]
        [InlineData(new int[] { -2, 0, -1 }, 0)]
        [InlineData(new int[] { -4, -3 }, 12)]
        [InlineData(new int[] { -2, 3, -4 }, 24)]
        public static void MaxProductTest(int[] n, int expected)
        {
            Assert.Equal(expected, DynamicProgramming.MaxProduct(n));
        }

        [Theory]
        [InlineData(3, 2, 3)]
        public static void UniquePathsTest(int m, int n, int expected)
        {
            Assert.Equal(expected, DynamicProgramming.UniquePaths(m,n));
        }

        [Fact]
        public static void MinimumTotalTest()
        {
            /*
            var input = new int[][]
            {
                new int[] {2 },
                new int[] {3, 4 },
                new int[] {6, 5, 7},
                new int[] {4, 1, 8, 3},

            };
            */

            var input = new int[][]
                {
                    new int[] {-1},
                    new int[] {-2, -3}
                };

            Assert.Equal(-4, DynamicProgramming.MinimumTotal(input));
        }

        [Fact]
        public static void FindLongestChainTest()
        {
            /*
            var input = new int[][]
                {
                    new int[] {2, 3},
                    new int[] {4, 5},
                    new int[] {0, 6},
                    new int[] {7, 9},
                    new int[] {6, 9},
                    new int[] {11, 12},
                    new int[] {13, 14}
                };
                */

            var input = new int[][]
                {
                    new int[] {-10,-8},
                    new int[] {8,9},
                    new int[] {-5,0},
                    new int[] {6,10},
                    new int[] {-6,-4},
                    new int[] {1,7},
                    new int[] { 9, 10 },
                    new int[] { -4,7 },
                };

            Assert.Equal(4, DynamicProgramming.FindLongestChain(input));
        }

        [Theory]
        [InlineData(new int[] { 0, 2, 3 }, false)]
        public static void CanJumpTest(int[] input, bool expected)
        {
            Assert.Equal(expected, DynamicProgramming.CanJump(input));
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 5 }, 11, 3)]
        [InlineData(new int[] { 2 }, 3, -1)]
        public static void CoinChangeTest(int[] input, int total, int expected)
        {
            Assert.Equal(expected, DynamicProgramming.CoinChangeBottomUp(input, total));
        }

        
    }
}
