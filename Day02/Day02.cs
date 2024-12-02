using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Day02
{
    internal class Day02
    {
        public static void Solve()
        {
            var input = File.ReadAllLines(@"Day02\input.txt");

            var reportList = input.Select(s => s.Split(' ')).Select(n => n.Select(int.Parse).ToList()).ToList();

            var stopwatch = Stopwatch.StartNew();
            PartOne(reportList);
            stopwatch.Stop();
            Console.WriteLine($"PartOne execution time: {stopwatch.Elapsed.TotalMilliseconds} ms");

            stopwatch = Stopwatch.StartNew();
            PartTwo(reportList);
            stopwatch.Stop();
            Console.WriteLine($"PartTwo execution time: {stopwatch.Elapsed.TotalMilliseconds} ms");

        }

        private static void PartOne(List<List<int>> reportList)
        {
            var safeCount = 0;
            foreach (var report in from report in reportList let order = CheckOrder(report) where order != 0 select report)
            {
                var n = 0;
                for (var i = 0; i < report.Count - 1; i++)
                {
                    var delta = Math.Abs(report[i] - report[i + 1]);
                    if (delta is >= 1 and <= 3)
                        n++;
                }

                if (n == report.Count - 1)
                    safeCount++;
            }

            Console.WriteLine(safeCount);
        }

        private static void PartTwo(List<List<int>> reportList)
        {
            foreach (var report in reportList)
            {
                var n = CompareLists(report, report.OrderBy(i => i).ToList());
                //if (CompareLists(report, report.OrderBy(i => i).ToList()) == 1)
                //{
                //    // report with one faulty number

                //}
            }
        }

        private static int CheckOrder(List<int> list)
        {
            var isAscending = true;
            var isDescending = true;

            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] < list[i - 1])
                {
                    isAscending = false;
                }
                if (list[i] > list[i - 1])
                {
                    isDescending = false;
                }
            }

            if (isAscending)
            {
                return 1;
            }

            if (isDescending)
            {
                return -1;
            }

            return 0;
        }

        private static int CompareLists(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count)
            {
                throw new ArgumentException("Lists must be of the same length");
            }

            return list1.Where((t, i) => t != list2[i]).Count();
        }
    }
}
