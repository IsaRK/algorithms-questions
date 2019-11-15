using System;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var nbTestCases = int.Parse(Console.ReadLine());

            while(nbTestCases > 0)
            {
                var sizes = Console.ReadLine();
                var a = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));
                var b = Array.ConvertAll(Console.ReadLine().Split(' '), x => int.Parse(x));

                Console.WriteLine(String.Join(' ', RelativeSorting.RelativeSortingImpl(a, b)));
                nbTestCases--;
            }


        }
    }
}
