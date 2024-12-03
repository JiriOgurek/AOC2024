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
            for (var i = 0; i < reportList.Count; i++)
            {
                //dups removal
                if (reportList[i].Distinct().Count() != reportList[i].Count)
                {
                    reportList[i] = reportList[i].Distinct().ToList();
                    continue;
                }

                //extreme delta removal
                var deltaList = GetDeltaList(reportList[i]);
                if (deltaList.Any(x => x is > 3 or < -3))
                {
                    reportList[i] = reportList[i].Where(x => x is >= -3 and <= 3).ToList();
                    continue;
                }

            }
        }

        private static List<int> GetDeltaList(List<int> report)
        {
            var deltaList = new List<int>();
            for (var i = 0; i < report.Count - 1; i++)
            {
                var delta = report[i] - report[i + 1];
                deltaList.Add(delta);
            }

            return deltaList;
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
    }
}
