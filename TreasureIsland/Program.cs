using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureIsland
{
    /// <summary>
    /// https://leetcode.com/discuss/interview-question/347457
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const int gridSize = 4;
            char[][] grid = new char[gridSize][];
            grid[0] = new char[gridSize] { 'O', 'O', 'O', 'O' };
            grid[1] = new char[gridSize] { 'D', 'O', 'D', 'O' };
            grid[2] = new char[gridSize] { 'O', 'O', 'O', 'O' };
            grid[3] = new char[gridSize] { 'X', 'D', 'D', 'O' };

            int stepsToTreasure = bfs(grid);
            Console.WriteLine("The minimum route to treasure takes "+ stepsToTreasure +" steps.");
        }

        static int bfs(char[][] grid)
        {
            int steps = 0;

            if (grid == null)
            {
                return steps;
            }

            List<(int, int)> possibleDirections = new List<(int, int)>();
            possibleDirections.Add((0, 1));
            possibleDirections.Add((0, -1));
            possibleDirections.Add((1, 0));
            possibleDirections.Add((-1, 0));

            Queue<(int, int)> directionsToCheck = new Queue<(int, int)>();
            directionsToCheck.Enqueue((0,0));

            char treasure = 'X';
            char visited = 'V';
            while (directionsToCheck.Count > 0)
            {
                for(int i = 0; i < directionsToCheck.Count; i++)
                {
                    (int row, int col) = directionsToCheck.Dequeue();

                    if (grid[row][col] == treasure)
                    {
                        return steps;
                    }
                    grid[row][col] = visited;

                    foreach ((int possibleRow, int possibleCol) in possibleDirections)
                    {
                        int rowNext = row + possibleRow;
                        int colNext = col + possibleCol;

                        if (isSafeNextStep(grid, rowNext, colNext))
                        {
                            directionsToCheck.Enqueue((rowNext, colNext));
                        }
                    }
                }

                steps++;
            }

            return steps;
        }

        static bool isSafeNextStep(char[][] grid, int row, int col)
        {
            char danger = 'D';
            char visited = 'V';
            return (row < grid.Count() && col < grid.Count() && row >= 0 && col >= 0 && grid[row][col] != danger && grid[row][col] != visited);
        }
    }
}