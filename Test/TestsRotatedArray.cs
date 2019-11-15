using Algorithms;
using Xunit;

namespace Test
{
    public class TestsRotatedArray
    {
        [Theory]
        [InlineData(new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 }, 6)]
        [InlineData(new int[] { 5, 6, 7, 8, 9, 10, 1, 2 }, 6)]
        public static void Test(int[] input, int expected)
        {
            Assert.Equal(expected, RotatedArray.FindPivotInRotatedArray(input));
        }

    }
}
