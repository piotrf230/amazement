using UnityEngine;
using UnityEngine.UIElements;
using Maze;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private UIDocument uIDocument;
    [SerializeField] private GlobalVariables globals;

    private SliderInt heightSlider;
    private SliderInt widthSlider;
    private SliderInt targetSlider;

    private DropdownField typeDropdown;
    private DropdownField algorithm;

    private Dictionary<string, MazeGenAlgDelegate> algorithmDelegates;

    [SerializeField] private List<MazePrefab> mazePrefabs;

    private void Awake()
    {
        SetAlgorithmDelegates();

        VisualElement root = uIDocument.rootVisualElement;

        AssignElements(root);
        AssignButtonActions(root);

        typeDropdown.choices = (from pref in mazePrefabs select pref.MenuName).ToList();
        typeDropdown.index = 0;

        algorithm.choices = algorithmDelegates.Keys.ToList();
        algorithm.index = 0;
    }

    private void AssignButtonActions(VisualElement root)
    {
        root.Q<Button>("Start").clicked += StartGame;
        root.Q<Button>("Exit").clicked += Exit;
    }

    private void AssignElements(VisualElement root)
    {
        heightSlider = root.Q<SliderInt>("Height");
        widthSlider = root.Q<SliderInt>("Width");
        targetSlider = root.Q<SliderInt>("Targets");

        typeDropdown = root.Q<DropdownField>("Type");
        algorithm = root.Q<DropdownField>("Algorithm");
    }

    private void SetAlgorithmDelegates()
    {
        algorithmDelegates = new Dictionary<string, MazeGenAlgDelegate>();
        algorithmDelegates.Add("Kruskal's Algorithm", MazeGenAlgorithm.Kruskal);
    }

    private void StartGame()
    {
        globals.Size.x = widthSlider.value;
        globals.Size.y = heightSlider.value;
        globals.TargetCount = targetSlider.value;
        globals.Algorithm = algorithmDelegates[algorithm.value];
        globals.Prefab = mazePrefabs[typeDropdown.index];

        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
