using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    public class HexMaze : MazeBase
    {
        private const float xDist = 0.8659766f;
        private const float yDist = 0.7499577f;

        public HexMaze(Vector2Int size, MazeGenAlgDelegate algorithm)
            : base(size, algorithm) { }
        public HexMaze(int width, int height, MazeGenAlgDelegate algorithm)
            : base(width, height, algorithm) { }

        public override Vector3 GetCell(int x, int y)
        {
            Vector3 result = new Vector3(x, y, 0);
            result *= 2;
            if (y % 2 == 1) result.x += 1f;

            result.x *= xDist;
            result.y *= yDist;

            return result;
        }

        public override TileChangeData[] GetTiles(MazeTileSet tileSet)
        {
            if (tileSet == null)
                throw new ArgumentNullException(nameof(tileSet));

            List<TileChangeData> result = new List<TileChangeData>();

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    Vector3Int position = new Vector3Int(2 * x, 2 * y, 0);
                    if (y % 2 == 1) position.x += 1;

                    result.Add(new TileChangeData(
                        position,
                        tileSet[Cell.Side.CENTER],
                        Color.white,
                        Matrix4x4.identity));

                    if (cells[x, y][Cell.Side.NE])
                    {
                        Vector2Int dest = GetNeighbourPosition(position.x, position.y, Cell.Side.NE);
                        result.Add(new TileChangeData(
                            new Vector3Int(dest.x, dest.y, 0),
                            tileSet[Cell.Side.NE],
                            Color.white,
                            Matrix4x4.identity));
                    }

                    if (cells[x, y][Cell.Side.E])
                    {
                        Vector2Int dest = GetNeighbourPosition(position.x, position.y, Cell.Side.E);
                        result.Add(new TileChangeData(
                            new Vector3Int(dest.x, dest.y, 0),
                            tileSet[Cell.Side.E],
                            Color.white,
                            Matrix4x4.identity));
                    }

                    if (cells[x, y][Cell.Side.SE])
                    {
                        Vector2Int dest = GetNeighbourPosition(position.x, position.y, Cell.Side.SE);
                        result.Add(new TileChangeData(
                            new Vector3Int(dest.x, dest.y, 0),
                            tileSet[Cell.Side.SE],
                            Color.white,
                            Matrix4x4.identity));
                    }
                }

            return result.ToArray();
        }

        public override Cell.Side SideFromDirection(Vector2 dir)
        {
            if (dir.magnitude < .1f)
                return Cell.Side.CENTER;

            float angle = Vector2.SignedAngle(Vector2.up, dir);

            if (angle > 120)
                return Cell.Side.SW;
            else if (angle <= 120 && angle >= 60)
                return Cell.Side.W;
            else if (angle >= 0 && angle < 60)
                return Cell.Side.NW;
            else if (angle < 0 && angle > -60)
                return Cell.Side.NE;
            else if (angle <= -60 && angle >= -120)
                return Cell.Side.E;
            else
                return Cell.Side.SE;
        }

        public override Vector2Int VectorFromSide(Cell.Side dir, Vector2Int? startPoint = null)
        {
            Vector2Int result;
            bool offset = startPoint != null && startPoint.Value.y % 2 == 1;
            switch (dir)
            {
                case Cell.Side.NE:
                    result = Vector2Int.up;
                    if (offset)
                        result.x += 1;
                    break;
                case Cell.Side.E:
                    result = Vector2Int.right;
                    break;
                case Cell.Side.SE:
                    result = Vector2Int.down;
                    if (offset)
                        result.x += 1;
                    break;
                case Cell.Side.SW:
                    result = new Vector2Int(-1, -1);
                    if (offset)
                        result.x += 1;
                    break;
                case Cell.Side.W:
                    result = Vector2Int.left;
                    break;
                case Cell.Side.NW:
                    result = new Vector2Int(-1, 1);
                    if (offset)
                        result.x += 1;
                    break;
                default:
                    return Vector2Int.zero;
            }

            return result;
        }

        public override float? AngleFromSide(Cell.Side dir)
        {
            switch (dir)
            {
                case Cell.Side.NE: return 30;
                case Cell.Side.E: return 90;
                case Cell.Side.SE: return 150;
                case Cell.Side.SW: return 210;
                case Cell.Side.W: return 270;
                case Cell.Side.NW: return 330;
                default: return null;
            }
        }

        internal override Cell.Side[] GetHalfSides(int x, int y)
        {
            List<Cell.Side> sides = new List<Cell.Side>();

            if (x < Width - 1) sides.Add(Cell.Side.E);

            bool offsetCondition = (y % 2 == 1 && x < Width - 1) || y % 2 == 0;
            if (y < Height - 1 && offsetCondition)
                sides.Add(Cell.Side.NE);
            if (y > 0 && offsetCondition)
                sides.Add(Cell.Side.SE);

            return sides.ToArray();
        }

        internal override Vector2Int GetNeighbourPosition(int x, int y, Cell.Side side)
        {
            Vector2Int result = new Vector2Int(x, y);
            result += VectorFromSide(side, result);

            return result;
        }

        internal override Cell.Side[] GetSides(int x, int y)
        {
            List<Cell.Side> sides = GetHalfSides(x, y).ToList();

            if (x > 0) sides.Add(Cell.Side.W);

            bool offsetCondition = (y % 2 == 0 && x > 0) || y % 2 == 1;
            if (y < Height - 1 && offsetCondition)
                sides.Add(Cell.Side.NW);
            if (y > 0 && offsetCondition)
                sides.Add(Cell.Side.SW);

            return sides.ToArray();
        }
    }

}