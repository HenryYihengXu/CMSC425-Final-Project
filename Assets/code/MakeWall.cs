using UnityEngine;

public class MakeWall : MonoBehaviour
{
    public bool isAlongX = true;
    
    public Vector3 wallStart;
    public int wallRows;
    public int wallCols;

    public bool hasWindow = true;
    public bool isHoleNotWindow = false;
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
        wall = Instantiate<GameObject>(wall, wallStart, Quaternion.identity);
        wall.name = "Wall";
        wallBody = Instantiate<GameObject>(wallBody, wallStart, Quaternion.identity, wall.transform);
        wallBody.name = "WallBody";

        if (hasWindow)
        {
            window = Instantiate<GameObject>(window, wallStart, Quaternion.identity, wall.transform);
            window.name = "Window";
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
                    
                    if (isAlongX)
                    {
                        door = Instantiate<GameObject>(door, place, Quaternion.identity, wall.transform);
                    }
                    else
                    {
                        door = Instantiate<GameObject>(door, place, Quaternion.Euler(0,-90,0), wall.transform);
                    }
                    door.name = "Door";
                }
                else if (hasDoor && row >= doorStartRow && row <= doorEndRow && col >= doorStartCol && col <= doorEndCol)
                {
                    continue;
                }
                else if (hasDoor && row >= doorStartRow - 2 && row < doorStartRow + 4)
                {
                    wallCube = Instantiate<GameObject>(wallCube, place, Quaternion.identity, wallBody.transform);
                    wallCube.name = "WallCube";
                }
                else if (hasWindow && row >= windowStartRow && row <= windowEndRow && col >= windowStartCol && col <= windowEndCol)
                {
                    if (isHoleNotWindow)
                    {
                        continue;
                    }
                    windowCube = Instantiate<GameObject>(windowCube, place, Quaternion.identity, window.transform);
                    windowCube.name = "WindowCube";
                }
                else
                {
                    wallCube = Instantiate<GameObject>(wallCube, place, Quaternion.identity, wallBody.transform);
                    wallCube.name = "WallCube";
                }
            }
        }
    }
}
