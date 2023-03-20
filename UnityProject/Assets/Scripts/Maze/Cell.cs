using System.Collections.Generic;

namespace Maze
{
    public class Cell
    {
        #region Sides
        public enum Side
        {
            CENTER = 0,
            N = 1,
            NE = 2,
            E = 3,
            SE = 4,
            S = -1,
            SW = -2,
            W = -3,
            NW = -4
        }
        public static Side Opposite(Side side) => (Side)(-(int)side);
        #endregion

        private static uint newId = 0;

        private List<Side> sides;
        public uint Id { get; set; }
        public int SideCount => sides.Count;
        public Side[] Sides => sides.ToArray();

        public Cell()
        {
            sides = new List<Side>();
            Id = newId++;
        }

        public bool this[Side side]
        {
            get => sides.Contains(side);
            set
            {
                if (value && !sides.Contains(side))
                    sides.Add(side);
            }
        }
    }
}