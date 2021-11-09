using System.Collections.Generic;
using UnityEngine;

public class PyramidGenerator : IGenerable
{
    public int weight = 14;
    public int lenght = 14;

    public Vector3[] TargetCalculate()
    {
        int height = ((weight + lenght) / 2 + 1) / 2;
        float yOffset = 2f;
        float scale = 2;
        List<Vector3> points = new List<Vector3>();

        for (int y = 0; y < height; y++)
        {
            for (int x = y - (weight / 2); x <= (weight - 1) / 2 - y; x++)
            {
                for (int z = y - (lenght / 2); z <= (lenght - 1) / 2 - y; z++)
                {
                    points.Add(new Vector3(x, y + yOffset, z) * scale);
                }
            }
        }


        return points.ToArray();
    }

}
