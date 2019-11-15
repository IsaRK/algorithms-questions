using Algorithms;
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
    }
}
