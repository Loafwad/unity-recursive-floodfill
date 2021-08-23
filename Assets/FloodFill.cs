using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    [SerializeField] private float fillDelay = 0.2f;
    private BoardManager board;
    void Start()
    {
        board = this.GetComponent<BoardManager>();
    }

    private IEnumerator Flood(int x, int y, Color oldColor, Color newColor)
    {
        WaitForSeconds wait = new WaitForSeconds(fillDelay);
        if (x >= 0 && x < board.xSize && y >= 0 && y < board.ySize)
        {
            yield return wait;
            if (board.grid[x, y].GetComponent<SpriteRenderer>().color == oldColor)
            {
                board.grid[x, y].GetComponent<SpriteRenderer>().color = newColor;
                StartCoroutine(Flood(x + 1, y, oldColor, newColor));
                StartCoroutine(Flood(x - 1, y, oldColor, newColor));
                StartCoroutine(Flood(x, y + 1, oldColor, newColor));
                StartCoroutine(Flood(x, y - 1, oldColor, newColor));
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int x = Random.Range(0, board.xSize);
            int y = Random.Range(0, board.ySize);
            if (board.grid[x, y].GetComponent<SpriteRenderer>().color != Color.white)
            {
                board.grid[x, y].GetComponent<SpriteRenderer>().color = Color.white;
            }
            StartCoroutine(Flood(x, y, Color.white, Color.red));
        }
    }
}
