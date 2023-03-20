using Maze;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private MazeController mazeController;
    [SerializeField] private Transform camTransform;
    [SerializeField, Range(.1f, 2f)] private float jumpTime = 1f;
    [SerializeField] GlobalVariables globals;
    private Controls controls;
    private float zlayer = -2;

    private Vector2Int dest;
    private Vector2Int next;

    private float stepTime;

    private void Awake()
    {
        controls = new Controls();
        SetControls();
        stepTime = 0;
    }

    private void Start()
    {
        dest = mazeController.PlayerStartingPoint;
        transform.position = mazeController.Maze.GetCell(dest);
    }

    private void Update()
    {
        Move();
        SyncCamera();
    }

    private void SetControls()
    {
        controls.Menu.Enter.performed += ctx => mazeController.BackToMenu();
        controls.Menu.Scroll.performed += ctx =>
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - ctx.ReadValue<float>() / 480f, 1f, 20f);
        controls.Menu.Exit.performed += ctx => mazeController.Exit();

        switch (globals.Prefab.Type)
        {
            case MazeType.RECT:
                controls.MoveRect.N.performed += ctx => Jump(Cell.Side.N);
                controls.MoveRect.E.performed += ctx => Jump(Cell.Side.E);
                controls.MoveRect.S.performed += ctx => Jump(Cell.Side.S);
                controls.MoveRect.W.performed += ctx => Jump(Cell.Side.W);
                break;
            case MazeType.HEX:
                controls.MoveHex.NE.performed += ctx => Jump(Cell.Side.NE);
                controls.MoveHex.E.performed += ctx => Jump(Cell.Side.E);
                controls.MoveHex.SE.performed += ctx => Jump(Cell.Side.SE);
                controls.MoveHex.NW.performed += ctx => Jump(Cell.Side.NW);
                controls.MoveHex.W.performed += ctx => Jump(Cell.Side.W);
                controls.MoveHex.SW.performed += ctx => Jump(Cell.Side.SW);
                break;
        }
    }

    private void Move()
    {
        stepTime += Time.deltaTime;

        Vector3 realDest = mazeController.Maze.GetCell(dest);
        realDest.z = zlayer;

        transform.position = Vector3.Lerp(transform.position, realDest, stepTime / jumpTime);

        if (stepTime > jumpTime || realDest == transform.position)
        {
            dest += next;
            next = Vector2Int.zero;
            mazeController.CheckCell(dest);
            stepTime = 0;
        }
    }

    private void SyncCamera()
    {
        Vector3 trans = transform.position;
        trans.z = camTransform.position.z;
        camTransform.position = trans;
    }

    private void Jump(Cell.Side side)
    {
        if (globals.won)
            return;

        if (CanJump(side))
            next = mazeController.Maze.VectorFromSide(side, dest);
        
    }

    private bool CanJump(Cell.Side dir) =>
        mazeController == null ? false : mazeController.Maze.IsMovePossible(dest, dir);

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

}
