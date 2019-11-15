using Algorithms;
using Xunit;

namespace Test
{
    public class GreedyTest
    {
        [Theory]
        [InlineData(new int[] { 1, 3 }, 2)]
        [InlineData(new int[] { 3, 7, 8}, 2)]
        [InlineData(new int[] { 2, 7, 4, 1, 8, 1 }, 1)]
        public static void LastStoneWeightTest(int[] n, int expected)
        {
            Assert.Equal(expected, Greedy.LastStoneWeight(n));
        }
    }
}
