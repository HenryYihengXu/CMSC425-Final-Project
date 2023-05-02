using UnityEngine;

public class MakeAlcove : MonoBehaviour
{
    public Vector3 wallStart;
    public int wallRows;
    public int wallCols;
    public int wallDepth;

    public bool hasAlcove = true;
    public int alcoveStartRow;
    public int alcoveStartCol;
    public int alcoveEndRow;
    public int alcoveEndCol;
    public int alcoveDepth;

    public GameObject wall;
    public GameObject wallBody;
    public GameObject wallCube;
    public GameObject shelfCube;

    void Start()
    {
        wall = Instantiate<GameObject>(wall, wallStart, Quaternion.identity);
        wall.name = "Wall";
        wallBody = Instantiate<GameObject>(wallBody, wallStart, Quaternion.identity, wall.transform);
        wallBody.name = "WallBody";

        for (int depth = 0; depth < wallDepth; ++depth) {
            Vector3 place = wallStart;
            place.z = wallStart.z + depth;

            for (int row = 0; row < wallRows; ++row)
            {
                place.x = wallStart.x + row;

                for (int col = 0; col < wallCols; ++col)
                {
                    place.y = wallStart.y + col;

                    if (hasAlcove && row >= alcoveStartRow && row <= alcoveEndRow && col <= alcoveEndCol && col == alcoveStartCol - 1)
                    {
                        shelfCube = Instantiate<GameObject>(shelfCube, place, Quaternion.identity, wallBody.transform);
                        shelfCube.name = "ShelfCube";

                    }
                    else if (!hasAlcove || row < alcoveStartRow || row > alcoveEndRow || col < alcoveStartCol || col > alcoveEndCol || depth > alcoveDepth)
                    {
                        wallCube = Instantiate<GameObject>(wallCube, place, Quaternion.identity, wallBody.transform);
                        wallCube.name = "WallCube";

                    }
                }
            }
        }
    }
}
