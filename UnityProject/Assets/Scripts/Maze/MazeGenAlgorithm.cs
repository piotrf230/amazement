using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Maze
{

    public delegate MazeBase MazeGenAlgDelegate(MazeBase maze);
    public static class MazeGenAlgorithm
    {
        public static MazeBase Kruskal(MazeBase maze)
        {
            List<(Vector2Int pos, Cell.Side side)> walls = new List<(Vector2Int pos, Cell.Side side)>();
            for (int i = 0; i < maze.Width; i++)
                for (int j = 0; j < maze.Height; j++)
                    foreach (Cell.Side side in maze.GetHalfSides(i, j))
                        walls.Add((new Vector2Int(i, j), side));

            System.Random r = new System.Random();
            walls = walls.OrderBy(x => r.Next()).ToList();
            r = null;

            foreach ((Vector2Int pos, Cell.Side side) wall in walls)
            {
                Vector2Int oPos = maze.GetNeighbourPosition(wall.pos, wall.side);

                if (maze[wall.pos.x, wall.pos.y] == maze[oPos.x, oPos.y])
                    continue;
                else
                    maze.Merge(wall.pos, wall.side);
            }

            return maze;
        }
    }
}