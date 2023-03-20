using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maze;
using System;

[CreateAssetMenu(fileName = "Globals", menuName = "Globals")]
public class GlobalVariables : ScriptableObject
{ 
    [Header("Maze Creation")]
    public Vector2Int Size;
    public int TargetCount;
    public MazePrefab Prefab;
    public MazeGenAlgDelegate Algorithm;

    [Header("Points")]
    public int Points;
    public int MaxPoints => TargetCount;
    public Action UpdateAction;

    public bool won;

    public void AddPoint()
    {
        Points++;
        if (UpdateAction != null) UpdateAction();
    }
}
