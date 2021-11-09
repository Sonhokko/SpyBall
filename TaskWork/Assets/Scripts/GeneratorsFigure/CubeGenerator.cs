using UnityEngine;

public class CubeGenerator : IGenerable
{
    public int weight = 10;
    public int height = 10;
    public int lenght = 10;

    public Vector3[] TargetCalculate()
    {
        float yOffset = 2f;
        float scale = 2;
        int i = 0;

        Vector3[] points = new Vector3[weight * height * lenght];

        for (int x = -(weight / 2); x <= (weight - 1) / 2; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = -(lenght / 2); z <= (lenght - 1) / 2; z++)
                {
                    points[i] = new Vector3(x, y + yOffset, z) * scale;
                    i++;
                }
            }
        }

        return points;
    }
}
