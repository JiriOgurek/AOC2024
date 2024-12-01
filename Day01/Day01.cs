using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Day01
{
    internal static class Day01
    {
        public static void Solve()
        {
            var input = File.ReadAllLines(@"Day01\input.txt");

            var leftList = new List<int>();
            var rightList = new List<int>();
            
            foreach (var s in input)
            {
                var n = s.Split("   ");
                leftList.Add(int.Parse(n[0]));
                rightList.Add(int.Parse(n[1]));
            }

            PartOne(leftList, rightList);
            PartTwo(leftList, rightList);
        }

        private static void PartTwo(List<int> leftList, List<int> rightList)
        {
            var sum = leftList.Sum(i => rightList.Count(t => t == i) * i);

            Console.WriteLine(sum);
        }

        private static void PartOne(List<int> leftList, List<int> rightList)
        {
            leftList.Sort();
            rightList.Sort();

            var sum = leftList.Select((t, i) => t >= rightList[i] ? t - rightList[i] : rightList[i] - t).Sum();

            Console.WriteLine(sum);
        }
    }
}
