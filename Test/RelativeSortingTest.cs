using GFGTests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class RelativeSortingTest
    {
        [Theory]
        [InlineData(new int[] { 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8, }, new int[] { 2, 1, 8, 3 }, new int[]{2, 2, 1, 1, 8, 8, 3, 5, 6, 7, 9})]
        [InlineData(new int[] { 9, 8, 5, 0, 3, 8, 9, 0 }, new int[] { 0, 9 }, new int[] { 0, 0, 9, 9, 3, 5, 8, 8 })]
        public static void Test(int[] a, int[] b, int[] expected)
        {
            Assert.Equal(expected, RelativeSorting.RelativeSortingImpl(a, b));
        }
    }
}
