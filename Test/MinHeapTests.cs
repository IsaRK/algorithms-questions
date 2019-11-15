using Algorithms;
using Xunit;

namespace Test
{
    public class MinHeapTests
    {
        [Theory]
        [InlineData(new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 }, 3, new int[] { 1,2,3})]
        [InlineData(new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 }, 4, new int[] { 1,2,3,5 })]
        public static void Test(int[] input, int nbMin, int[] expected)
        {
            Assert.Equal(expected, GfGTests.getKthMinElementInArray(input, nbMin));
        }
    }
}
