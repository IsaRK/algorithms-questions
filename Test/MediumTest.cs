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
    }
}
