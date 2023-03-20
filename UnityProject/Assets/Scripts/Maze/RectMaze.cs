using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    public class RectMaze : MazeBase
    {
        public RectMaze(Vector2Int size, MazeGenAlgDelegate algorithm)
            : base(size, algorithm) { }
        public RectMaze(int width, int height, MazeGenAlgDelegate algorithm)
            : base(width, height, algorithm) { }

        internal override Cell.Side[] GetSides(int x, int y)
        {
            Cell.Side[] sides = GetHalfSides(x, y);
            if (x > 0) sides = sides.Append(Cell.Side.W).ToArray();
            if (y > 0) sides = sides.Append(Cell.Side.S).ToArray();

            return sides;
        }

        internal override Cell.Side[] GetHalfSides(int x, int y)
        {
            List<Cell.Side> sides = new List<Cell.Side>();
            if (x < Width - 1) sides.Add(Cell.Side.E);
            if (y < Height - 1) sides.Add(Cell.Side.N);

            return sides.ToArray();
        }

        internal override Vector2Int GetNeighbourPosition(int x, int y, Cell.Side side)
        {
            switch (side)
            {
                case Cell.Side.N: return new Vector2Int(x, y + 1);
                case Cell.Side.E: return new Vector2Int(x + 1, y);
                case Cell.Side.S: return new Vector2Int(x, y - 1);
                case Cell.Side.W: return new Vector2Int(x - 1, y);
                default:
                    throw new ArgumentException("Invalid Side requested!", nameof(side));
            }
        }

        public override TileChangeData[] GetTiles(MazeTileSet tileSet)
        {
            if (tileSet == null)
                throw new ArgumentNullException(nameof(tileSet));

            List<TileChangeData> result = new List<TileChangeData>();

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    result.Add(new TileChangeData(
                        new Vector3Int(x * 2, y * 2, 0),
                        tileSet[Cell.Side.CENTER],
                        Color.white,
                        Matrix4x4.identity));

                    if (cells[x, y][Cell.Side.E])
                        result.Add(new TileChangeData(
                            new Vector3Int(x * 2 + 1, y * 2, 0),
                            tileSet[Cell.Side.E],
                            Color.white,
                            Matrix4x4.identity));

                    if (cells[x, y][Cell.Side.S])
                        result.Add(new TileChangeData(
                            new Vector3Int(x * 2, y * 2 - 1, 0),
                            tileSet[Cell.Side.S],
                            Color.white,
                            Matrix4x4.identity));
                }

            return result.ToArray();
        }

        public override Cell.Side SideFromDirection(Vector2 dir)
        {
            if (dir.magnitude < .1f)
                return Cell.Side.CENTER;

            float angle = Vector2.SignedAngle(Vector2.up, dir);
            if (Math.Abs(angle) <= 45)
                return Cell.Side.N;
            else if (Math.Abs(angle) >= 135)
                return Cell.Side.S;
            else
                return angle > 0 ? Cell.Side.W : Cell.Side.E;
        }

        public override Vector2Int VectorFromSide(Cell.Side dir, Vector2Int? startPoint = null)
        {
            switch (dir)
            {
                case Cell.Side.N:
                    return Vector2Int.up;
                case Cell.Side.S:
                    return Vector2Int.down;
                case Cell.Side.W:
                    return Vector2Int.left;
                case Cell.Side.E:
                    return Vector2Int.right;
                default:
                    return Vector2Int.zero;
            }
        }

        public override float? AngleFromSide(Cell.Side dir)
        {
            switch (dir)
            {
                case Cell.Side.N: return 0;
                case Cell.Side.E: return 90;
                case Cell.Side.S: return 180;
                case Cell.Side.W: return 270;
                default: return null;
            }
        }

        public override Vector3 GetCell(int x, int y)
        {
            Vector3 result = new Vector3(.5f, .5f, 0);
            result.x += 2f * x;
            result.y += 2f * y;

            return result;
        }
    }
}
