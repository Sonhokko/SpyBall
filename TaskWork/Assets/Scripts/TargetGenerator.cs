using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform parent;

    public static TargetGenerator instance {get; private set;}

    IGenerable[] generators =
    {
        new CubeGenerator(),
        new PyramidGenerator(),
        new RectangleGenerator(),
        new SphereGenerator()
    };

    private void Awake() => instance = this;

    private void Start()
    {
        Respawn();
    }

    private void OnSpawnPosition()
    {
        parent.position = Vector3.zero;
        parent.rotation = Quaternion.identity;
        parent.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        parent.position += parent.forward * Random.Range(100, 225);
        parent.LookAt(Vector3.zero, Vector3.up);
    }

    public void Respawn()
    {
        OnSpawnPosition();
        GenerateTarget();
    }

    public void GenerateTarget()
    {
        for (int i = 0; i < parent.childCount; i++)
            Destroy(parent.GetChild(i).gameObject);

        Vector3[] points = generators[Random.Range(0, generators.Length)].TargetCalculate();

        foreach (Vector3 point in points)
        {
            GameObject tile = Instantiate(prefabs[Random.Range(0, prefabs.Length)], parent);
            tile.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
            tile.transform.localPosition = point;
        }
    }
}
