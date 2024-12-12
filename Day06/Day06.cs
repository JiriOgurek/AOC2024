using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AOC2024.Day06
{
    internal class Day06
    {
        private char[,] Array { get; set; }
        private (int, int) Coords => GetCoords(Array);
        private char Direction => GetGuardDirection(Array, Coords);

        public void Solve()
        {
            PartOne();
        }

        private void PartOne()
        {
            Array = CreateArray(@"Day06\input.txt");
        }

        private static char[,] CreateArray(string input)
        {
            // Read all lines from the input
            var lines = File.ReadAllLines(input);

            // Determine the number of rows and columns
            var rows = lines.Length;
            var cols = lines[0].Length;

            // Initialize the two-dimensional array
            var array = new char[rows, cols];

            // Populate the array with characters from the input
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    array[i, j] = lines[i][j];
                }
            }

            return array;
        }

        private static (int, int) GetCoords(char[,] array)
        {
            var rows = array.GetLength(0);
            var cols = array.GetLength(1);
            for (var x = 0; x < rows; x++)
            {
                for (var y = 0; y < cols; y++)
                {
                    if (array[x, y] != '.' && array[x, y] != '#')
                    {
                        return (x, y);
                    }
                }
            }
            return (-1, -1);
        }

        private static char GetGuardDirection(char[,] array, (int, int) coords)
        {
            var (x, y) = coords;
            return array[x, y];
        }
    }
}
