using Algorithms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Test
{
    public static class OtherQuestionsTest
    {
        [Fact]
        public static void StackFromQueueTest()
        {
            var maStack = new OtherQuestions.StackFromQueue();

            maStack.Push(1);
            maStack.Push(2);
            maStack.Push(3);

            Assert.Equal(3, maStack.Pop());
        }

        [Fact]
        public static void FibTest()
        {
            var watch = new Stopwatch();
            watch.Start();
            Assert.Equal(89, OtherQuestions.Fib(11));
            watch.Stop();
            Trace.WriteLine(watch.ElapsedMilliseconds);

            watch.Reset();
            watch.Start();
            Assert.Equal(89, OtherQuestions.FibRec(11));
            watch.Stop();
            Trace.WriteLine(watch.ElapsedMilliseconds);
        }

        [Theory]
        [InlineData(new int[] { 5, 6, 10, 1, 4, 3, 7, 0, 11, 3 }, new int[] { 7, 8, 11 })]
        [InlineData(new int[] { 8, 9, 10}, new int[] { 0, 2, 2 })]
        [InlineData(new int[] { 10, 8, 9 }, new int[] { 1, 2, 1 })]
        [InlineData(new int[] { 7, 6, 9, 6, 2 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 7, 6, 9, 9, 9, 6, 2 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 7, 8, 6, 9,6, 2 }, new int[] { 2, 3, 3 })]
        public static void HistoriqueMarcheTest(int[] input, int[] expected)
        {
            Assert.Equal(expected, OtherQuestions.HistoriqueMarche(input));
        }

        [Fact]
        public static void fizzBuzzTest()
        {
            OtherQuestions.fizzBuzz(15);
        }

        [Fact]
        public static void betterCompressionTest()
        {
            Assert.Equal("a3b2c10", OtherQuestions.betterCompression("a3c9b2c1"));
            Assert.Equal("a351z211", OtherQuestions.betterCompression("z210a350z1a1"));
            Assert.Equal("a10", OtherQuestions.betterCompression("a10"));
        }

        [Fact]
        public static void countPermsTest()
        {
            Assert.Equal(5, OtherQuestions.countPerms(1));
            Assert.Equal(10, OtherQuestions.countPerms(2));
            Assert.Equal(19, OtherQuestions.countPerms(3));
            Assert.True(OtherQuestions.countPerms(99999) > 0);
        }

        [Fact]
        public static void PoidMaxTest()
        {
            Assert.Equal(1250, OtherQuestions.PoidMax(new List<List<int>> { new List<int> { 1000, 50 }, new List<int> { 600, 40 } },
                new List<List<int>> { new List<int> { 20, 40 }, new List<int> { 15, 80 } },
                100));
        }

        

    }
}
