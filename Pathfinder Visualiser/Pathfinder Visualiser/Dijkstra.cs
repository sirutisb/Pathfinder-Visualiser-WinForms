using New_Pathfinder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder_Visualiser
{
    public static class Dijkstra
    {
        public static List<Point> FindPath(ref Grid[,] grid, Point startPos, Point endPos, int gridSize)
        {
            int maxGridSize = grid.GetLength(0);
            List<Point> path = new List<Point>();
            Queue<Point> visitedNodes = new Queue<Point>();
            Point currentPos = startPos;

            // Reset variables
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    grid[x, y].isVisited = false;
                    grid[x, y].distanceFromStart = maxGridSize * maxGridSize;
                    grid[x, y].previousVertex = new Point();
                }
            }


            grid[startPos.X, startPos.Y].distanceFromStart = 0;
            grid[startPos.X, startPos.Y].previousVertex = startPos;
            while (currentPos != endPos)
            {
                if (currentPos.Y > 0) // Up
                    VisitNode(currentPos, 0, -1, ref visitedNodes, ref grid);
                if (currentPos.X > 0) // Left
                    VisitNode(currentPos, -1, 0, ref visitedNodes, ref grid);
                if (currentPos.Y < gridSize - 1) // Down
                    VisitNode(currentPos, 0, 1, ref visitedNodes, ref grid);
                if (currentPos.X < gridSize - 1) // Right
                    VisitNode(currentPos, 1, 0, ref visitedNodes, ref grid);

                if (visitedNodes.Count == 0) // Reached dead end, path not found.
                    return null;

                grid[currentPos.X, currentPos.Y].isVisited = true;
                currentPos = visitedNodes.Dequeue();
            }

            Point previous = endPos;
            while (grid[previous.X, previous.Y].previousVertex != startPos) // Backtracking
            {
                previous = grid[previous.X, previous.Y].previousVertex;
                path.Add(previous);
            }
            path.Reverse();
            return path;
        }

        private static void VisitNode(Point currentPos, int x, int y, ref Queue<Point> visitedNodes, ref Grid[,] grid)
        {
            Point neighbourPos = new Point(currentPos.X + x, currentPos.Y + y);
            if (!grid[neighbourPos.X, neighbourPos.Y].isObstacle && !grid[neighbourPos.X, neighbourPos.Y].isVisited)
            {
                int currentDistance = grid[currentPos.X, currentPos.Y].distanceFromStart + 1;
                if (currentDistance < grid[neighbourPos.X, neighbourPos.Y].distanceFromStart)
                {
                    grid[neighbourPos.X, neighbourPos.Y].distanceFromStart = currentDistance;
                    grid[neighbourPos.X, neighbourPos.Y].previousVertex = currentPos;
                    visitedNodes.Enqueue(neighbourPos);
                }
            }
        }
    }
}
