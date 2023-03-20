using Maze;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using Random = System.Random;

public class MazeController : MonoBehaviour
{
    [Header("Maze settings")]
    [SerializeField] private GameObject particlesPrefab;

    [SerializeField] private GlobalVariables globalVariables;

    [Header("Other")]
    [SerializeField] private UIDocument uIDocument;
    private VisualElement rootElement;

    [Header("Instructions")]
    [SerializeField] private Texture2D RectInstr;
    [SerializeField] private Texture2D HexInstr;

    private Label QuitLabel;
    private Label pointsLabel;
    private VisualElement winScreen;
    private VisualElement instruction;

    private MazeTileSet tileSet;
    private Tilemap tileMap;
    private Transform destinationContainer;
    private GameObject destinationPrefab;

    public MazeBase Maze => maze;
    private MazeBase maze;

    public Vector2Int PlayerStartingPoint { get; private set; }
    private Dictionary<Vector2Int, GameObject> destinations;

    private bool back = false;

    private void Awake()
    {
        SetVariables();

        switch (globalVariables.Prefab.Type)
        {
            case MazeType.RECT:
                maze = new RectMaze(globalVariables.Size, globalVariables.Algorithm);
                break;
            case MazeType.HEX:
                maze = new HexMaze(globalVariables.Size, globalVariables.Algorithm);
                break;
            default:
                throw new Exception("No maze class assigned to type: " + globalVariables.Prefab.Type);
        }

        SetObjects();

        SetEnds();

        UpdateLabel();
    }

    private void SetVariables()
    {
        if (globalVariables == null)
            throw new NullReferenceException("No global variables object assigned!");
        if (uIDocument == null)
            throw new NullReferenceException("No UI DOcument assigned!");

        rootElement = uIDocument.rootVisualElement;
        pointsLabel = rootElement.Q<Label>("PointLabel");
        QuitLabel = rootElement.Q<Label>("QuitLabel");
        winScreen = rootElement.Q<VisualElement>("WinScreen");
        instruction = rootElement.Q<VisualElement>("Instruction");
        switch (globalVariables.Prefab.Type)
        {
            case MazeType.RECT:
                instruction.style.backgroundImage = new StyleBackground(RectInstr);
                break;
            case MazeType.HEX:
                instruction.style.backgroundImage = new StyleBackground(HexInstr);
                break;
            default:
                throw new Exception("No maze class assigned to type: " + globalVariables.Prefab.Type);
        }

        QuitLabel.style.display = DisplayStyle.None;
        winScreen.style.display = DisplayStyle.None;

        globalVariables.Points = 0;
        globalVariables.UpdateAction = UpdateLabel;
        globalVariables.won = false;
    }

    private void SetObjects()
    {
        GameObject grid = Instantiate(globalVariables.Prefab.Prefab, transform.parent);
        destinationPrefab = globalVariables.Prefab.Destination;
        tileSet = globalVariables.Prefab.TileSet;
        destinationContainer = MazePrefab.GetDestinationContainer(grid);
        tileMap = MazePrefab.GetTilemap(grid);
    }

    private void SetEnds()
    {
        System.Random r = new System.Random();
        Queue<Vector2Int> q = new Queue<Vector2Int>(maze.GetEnds().OrderBy(x => r.Next()));
        r = null;
        PlayerStartingPoint = q.Dequeue();

        destinations = new Dictionary<Vector2Int, GameObject>();

        int targ = globalVariables.TargetCount;
        while (targ-- > 0)
        {
            Vector2Int v = q.Dequeue();
            Vector3 newPos = maze.GetCell(v);
            newPos.z = -1;
            GameObject dest = Instantiate(destinationPrefab, newPos, Quaternion.identity, destinationContainer);
            destinations.Add(v, dest);
        }
    }

    void Start()
    {
        RenderMaze(maze);
    }

    private void RenderMaze(MazeBase maze)
    {
        if (tileSet == null || tileMap == null)
            throw new UnassignedReferenceException("Tile set or Tile map not assigned");

        tileMap.SetTiles(maze.GetTiles(tileSet), false);
    }

    public void CheckCell(Vector2Int cell)
    {
        if (destinations.Keys.Contains(cell))
        {
            Destroy(destinations[cell]);
            AddPoint(destinations[cell].transform.position);
            destinations.Remove(cell);
            if (destinations.Count == 0)
                Win();
        }
    }

    private void AddPoint(Vector3 particlePosition)
    {
        Instantiate(particlesPrefab, particlePosition, Quaternion.identity, destinationContainer);
        globalVariables.AddPoint();
    }

    private void UpdateLabel() =>
        pointsLabel.text = $"{globalVariables.Points}/{globalVariables.MaxPoints}";

    private void Win()
    {
        winScreen.style.display = DisplayStyle.Flex;
        StartCoroutine(Fireworks(.5f, 64));
        globalVariables.won = true;
    }

    IEnumerator Fireworks(float interval, int count)
    {
        for (int i = 0; i < count; i++)
        {

            Random rand = new Random();
            Vector3 screenpoint = new Vector3(
                rand.Next(Camera.main.scaledPixelWidth),
                rand.Next(Camera.main.scaledPixelHeight),
                0);
            Instantiate(particlesPrefab, Camera.main.ScreenToWorldPoint(screenpoint), Quaternion.identity, destinationContainer);

            yield return new WaitForSeconds((float)rand.NextDouble() * interval);
        }
    }

    public void Exit()
    {
        if (back)
            SceneManager.LoadScene(0);
        else
            StartCoroutine(WaitForEsc());
    }

    public void BackToMenu()
    {
        if (instruction.style.display.value == DisplayStyle.Flex)
            instruction.style.display = DisplayStyle.None;

        if (globalVariables.won) SceneManager.LoadScene(0);
    }

    private IEnumerator WaitForEsc()
    {
        back = true;
        QuitLabel.style.display = DisplayStyle.Flex;
        yield return new WaitForSeconds(3f);
        QuitLabel.style.display = DisplayStyle.None;
        back = false;
    }
}
