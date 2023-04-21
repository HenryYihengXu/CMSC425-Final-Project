using UnityEngine;

public class MakeWall : MonoBehaviour
{
    public bool isAlongX = true;
    
    public Vector3 wallStart;
    public int wallRows;
    public int wallCols;

    public bool hasWindow = true;
    public int windowStartRow;
    public int windowStartCol;
    public int windowEndRow;
    public int windowEndCol;

    public bool hasDoor = true;
    public int doorStartRow;
    public int doorStartCol;
    public int doorEndRow;
    public int doorEndCol;

    public GameObject wall;
    public GameObject wallBody;
    public GameObject window;
    public GameObject door;
    public GameObject wallCube;
    public GameObject windowCube;

    void Start()
    {
        bool[,] windowOccupied = new bool[wallRows,wallCols];
        bool[,] occupied = new bool[wallRows,wallCols];

        wall = Instantiate<GameObject>(wall, wallStart, Quaternion.identity);
        wallBody = Instantiate<GameObject>(wallBody, wallStart, Quaternion.identity);
        wall.name = "Wall";
        wallBody.name = "WallBody";
        wallBody.transform.parent = wall.transform;

        if (hasWindow)
        {
            window = Instantiate<GameObject>(window, wallStart, Quaternion.identity);
            window.name = "Window";
            window.transform.parent = wall.transform;
        }

        for (int row = 0; row < wallRows; ++row)
        {
            Vector3 place = wallStart;
            if (isAlongX)
            {
                place.x = wallStart.x + row;
            }
            else
            {
                place.z = wallStart.z + row;
            }

            for (int col = 0; col < wallCols; ++col)
            {
                place.y = wallStart.y + col;

                if (hasDoor && row == doorStartRow && col == doorStartCol)
                {
                    door = Instantiate<GameObject>(door, place, Quaternion.identity);
                    door.name = "Door";
                    door.transform.parent = wall.transform;
                }
                else if (hasDoor && row >= doorStartRow && row <= doorEndRow && col >= doorStartCol && col <= doorEndCol)
                {
                    continue;
                }
                else if (hasDoor && row >= doorStartRow - 2 && row < doorStartRow + 4)
                {
                    wallCube = Instantiate<GameObject>(wallCube, place, Quaternion.identity);
                    wallCube.name = "WallCube";
                    wallCube.transform.parent = wallBody.transform;
                }
                else if (hasWindow && row >= windowStartRow && row <= windowEndRow && col >= windowStartCol && col <= windowEndCol)
                {
                    windowCube = Instantiate<GameObject>(windowCube, place, Quaternion.identity);
                    windowCube.name = "WindowCube";
                    windowCube.transform.parent = window.transform;
                }
                else
                {
                    wallCube = Instantiate<GameObject>(wallCube, place, Quaternion.identity);
                    wallCube.name = "WallCube";
                    wallCube.transform.parent = wallBody.transform;
                }
            }
        }
        // wall.AddComponent<BoxCollider>();
        // BoxCollider wallCollider = wall.GetComponent<BoxCollider>();
        // if (isAlongX)
        // {
        //     wallCollider.center = new Vector3();
        // }
    }
}
