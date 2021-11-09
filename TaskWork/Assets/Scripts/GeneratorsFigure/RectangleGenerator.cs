using UnityEngine;

public class RectangleGenerator : IGenerable
{
    public Vector3[] TargetCalculate()
    {
        CubeGenerator cubeGenerator = new CubeGenerator();
        cubeGenerator.weight = 15;

        return cubeGenerator.TargetCalculate();
    }
}
