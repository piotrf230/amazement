using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    [CreateAssetMenu(fileName = "New Maze Tileset", menuName = "Maze/Tileset")]
    public class MazeTileSet : ScriptableObject
    {
        private Dictionary<Cell.Side, Tile> tileset;

        // Struct na potrzeby serializacji w inspectorze Unity
        [System.Serializable]
        private struct MTile
        {
            public Cell.Side side;
            public Tile tile;
        }
        [SerializeField] private MTile[] tiles;

        public Tile this[Cell.Side side]
        {
            get
            {
                if (tileset == null) OnTilesetChanged();

                if (tileset.ContainsKey(side))
                    return tileset[side];

                Cell.Side op = Cell.Opposite(side);
                if (tileset.ContainsKey(op))
                    return tileset[op];

                throw new ArgumentException($"Invalid Side: {side} ({op})", nameof(side));
            }
        }
        internal void OnTilesetChanged()
        {
            tileset = new Dictionary<Cell.Side, Tile>();
            foreach (MTile tile in tiles)
                tileset.Add(tile.side, tile.tile);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MazeTileSet))]
    public class MazeTileSetEditor : Editor
    {
        MazeTileSet tileset;

        private void OnEnable()
        {
            tileset = (MazeTileSet)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save"))
            {
                tileset.OnTilesetChanged();
                Debug.Log("Tileset Saved!");
            }
        }
    }
#endif
}