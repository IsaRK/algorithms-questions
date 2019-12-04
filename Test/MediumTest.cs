using Algorithms;
using Xunit;

namespace Test
{
    public class MediumTest
    {
        [Fact]
        public static void GenerateParenthesisTest()
        {
            Assert.NotNull(Medium.GenerateParenthesis(5));
        }

        [Fact]
        public static void SearchRangeTest()
        {
            var nums = new int[] { 5, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 10 };
            var target = 8;
            Assert.NotNull(Medium.SearchRange(nums, target));
        }

        [Fact]
        public static void LengthOfLongestSubstringTest()
        {
            Assert.Equal(3, Medium.LengthOfLongestSubstring("abcabcbb"));
        }

        [Fact]
        public static void LetterCombinationsTest()
        {
            Assert.NotNull(Medium.LetterCombinations("23"));
        }

        [Fact]
        public static void CombinationSumTest()
        {
            Assert.NotNull(Medium.CombinationSum(new int[] { 2, 3, 6, 7 }, 7));
        }

        [Fact]
        public static void PermuteTest()
        {
            Assert.NotNull(Medium.Permute(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public static void Combine()
        {
            Assert.NotNull(Medium.Combine(4, 2));
        }

        [Fact]
        public static void SubsetsTest()
        {
            Assert.NotNull(Medium.Subsets(new int[] { 1, 2, 3 }));
        }

        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 3, 1 })]
        [InlineData(new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 })]
        [InlineData(new int[] { 1, 2, 10, 5, 4 }, new int[] { 1, 4, 2, 5, 10 })]
        [InlineData(new int[] { 1, 4, 10, 5, 2 }, new int[] { 1, 5, 2, 4, 10 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4, 3 })]
        [InlineData(new int[] { 2, 1, 3 }, new int[] { 2, 3, 1 })]
        public static void NextPermutationTest(int[] n, int[] expected)
        {
            Medium.NextPermutation(n);
            Assert.Equal(expected, n);
        }

        
    }
}
