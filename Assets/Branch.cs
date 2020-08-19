using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    private void DrawNewBranch(float x, float y, int len, float angle, Color colour)
    {

        double x1, y1;
        x1 = x + len * Mathf.Sin(angle * Mathf.PI * 2 / 360);
        y1 = y + len * Mathf.Cos(angle * Mathf.PI * 2 / 360);
        if (len < 7f)
        {
            colour = Color.green;
        }
        Debug.DrawLine(new Vector2(x, y), new Vector2((int)x1, (int)y1), colour, 99999);

    }
}
