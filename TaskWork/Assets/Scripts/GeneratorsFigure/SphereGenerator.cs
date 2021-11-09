using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : IGenerable
{
    public int radius = 12;

    public Vector3[] TargetCalculate()
    {
        CubeGenerator cubeGenerator = new CubeGenerator();
        cubeGenerator.height = radius + 1;
        cubeGenerator.weight = radius + 1;
        cubeGenerator.lenght = radius + 1;

        Vector3 center = new Vector3(0f, cubeGenerator.height + 0.5f, 0f);
        Vector3[] cube = cubeGenerator.TargetCalculate();
        List<Vector3> points = new List<Vector3>();

        for (int i = 0; i < cube.Length; i++)
        {
            if (Vector3.Distance(center, cube[i]) <= radius)
                points.Add(cube[i]);
        }

        return points.ToArray();
    }
}
