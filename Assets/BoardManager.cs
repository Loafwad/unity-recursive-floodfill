using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabTile;
    public int xSize, ySize;
    public GameObject[,] grid;
    void Start()
    {
        CreateBoard(xSize, ySize);
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (Random.value < 0.2f)
                {
                    ColorTile(x, y, Color.black);
                }
            }
        }
    }

    private void ColorTile(int x, int y, Color color)
    {
        grid[x, y].GetComponent<SpriteRenderer>().color = color;
    }

    private Vector2 GetSize(GameObject tile)
    {
        return new Vector2(tile.GetComponent<SpriteRenderer>().bounds.size.x, tile.GetComponent<SpriteRenderer>().bounds.size.y);
    }

    private void CreateBoard(int width, int height)
    {
        grid = new GameObject[width, height];
        Vector2 startPos = this.transform.position;
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject tile = Instantiate(prefabTile);
                tile.transform.parent = this.transform;
                tile.transform.position = new Vector2(startPos.x + (GetSize(prefabTile).x * x), startPos.y + (GetSize(prefabTile).y * y));
                grid[x, y] = tile;
            }
        }
    }
}
