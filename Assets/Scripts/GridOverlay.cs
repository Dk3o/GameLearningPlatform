using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOverlay : MonoBehaviour
{
    public int rows = 10;
    public int cols = 10;
    public float cellSize = 1f;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int x = 0; x <= cols; x++)
        {
            Gizmos.DrawLine(new Vector3(x * cellSize, 0, 0), new Vector3(x * cellSize, rows * cellSize, 0));
        }
        for (int y = 0; y <= rows; y++)
        {
            Gizmos.DrawLine(new Vector3(0, y * cellSize, 0), new Vector3(cols * cellSize, y * cellSize, 0));
        }
    }
}
