using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    public enum MazeType
    {
        RECT, HEX
    }

    public abstract class MazeBase
    {
        protected Cell[,] cells;

        public Vector2Int Size { get => new Vector2Int(Width, Height); }
        public int Width { get => cells.GetLength(0); }
        public int Height { get => cells.GetLength(1); }

        public MazeBase(Vector2Int size, MazeGenAlgDelegate algorithm)
            : this(size.x, size.y, algorithm) { }
        public MazeBase(int width, int height, MazeGenAlgDelegate algorithm)
        {
            cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    cells[i, j] = new Cell();
            algorithm(this);
        }

        internal void Merge(Vector2Int pos, Cell.Side dir) =>
            Merge(pos.x, pos.y, dir);
        internal void Merge(int x, int y, Cell.Side dir)
        {
            cells[x, y][dir] = true;
            Vector2Int pos = GetNeighbourPosition(x, y, dir);

            cells[pos.x, pos.y][Cell.Opposite(dir)] = true;

            ChangeId(pos, this[x, y]);
        }

        internal abstract Cell.Side[] GetSides(int x, int y);
        internal abstract Cell.Side[] GetHalfSides(int x, int y);

        internal Vector2Int GetNeighbourPosition(Vector2Int pos, Cell.Side side) =>
            GetNeighbourPosition(pos.x, pos.y, side);
        internal abstract Vector2Int GetNeighbourPosition(int x, int y, Cell.Side side);

        protected void ChangeId(Vector2Int pos, uint newId) =>
            ChangeId(pos.x, pos.y, newId);
        protected void ChangeId(int x, int y, uint newId)
        {
            uint oldId = this[x, y];
            this[x, y] = newId;

            foreach (Cell.Side side in GetSides(x, y))
            {
                Vector2Int pos = GetNeighbourPosition(x, y, side);

                if (this[pos.x, pos.y] == oldId)
                    ChangeId(pos, newId);
            }
        }

        public abstract TileChangeData[] GetTiles(MazeTileSet tileSet);

        public Vector3 GetCell(Vector2Int cell) =>
            GetCell(cell.x, cell.y);
        public abstract Vector3 GetCell(int x, int y);

        public Vector2Int[] GetEnds()
        {
            List<Vector2Int> ends = new List<Vector2Int>();

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (cells[x, y].SideCount == 1)
                        ends.Add(new Vector2Int(x, y));

            return ends.ToArray();
        }

        public bool IsMovePossible(Vector2Int startPosition, Cell.Side dir) =>
            IsMovePossible(startPosition.x, startPosition.y, dir);
        public bool IsMovePossible(int x, int y, Cell.Side dir) =>
            cells[x, y][dir];

        public abstract Cell.Side SideFromDirection(Vector2 dir);
        public abstract Vector2Int VectorFromSide(Cell.Side dir, Vector2Int? startPoint = null);

        public abstract float? AngleFromSide(Cell.Side dir);

        public uint this[int x, int y]
        {
            get => cells[x, y].Id;
            set => cells[x, y].Id = value;
        }
    }
}
