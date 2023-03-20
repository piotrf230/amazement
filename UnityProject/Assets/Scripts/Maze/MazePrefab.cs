using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    [CreateAssetMenu(fileName = "New Maze Prefab", menuName = "Maze/Maze Prefab")]
    public class MazePrefab : ScriptableObject
    {
        [SerializeField] private string menuName;
        [SerializeField] private GameObject mazePrefab;
        [SerializeField] private MazeTileSet tileSet;
        [SerializeField] private GameObject destinationPrefab;
        [SerializeField] private MazeType type;

        public string MenuName => menuName;
        public MazeTileSet TileSet => tileSet;
        public GameObject Prefab => mazePrefab;
        public GameObject Destination => destinationPrefab;
        public MazeType Type => type;

        public static Transform GetDestinationContainer(GameObject mazePrefab) =>
            mazePrefab.transform.Find("DestinationContainer");
        public static Tilemap GetTilemap(GameObject mazePrefab) =>
            mazePrefab.GetComponentInChildren<Tilemap>();
    } 
}
