using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private GameObject missilepref;
    [SerializeField] private Camera camera;
    [SerializeField] private float throwForce = 60f;
    [SerializeField] private float speed;

    private float cameraX = 0f;

    public void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(Vector3.up * variableJoystick.Horizontal * speed);
        cameraX += variableJoystick.Vertical * speed;
        cameraX = Mathf.Clamp(cameraX, -90, 90);
        camera.transform.localRotation = Quaternion.Euler(-cameraX, 0, 0);
    }


    public void Shoot()
    {
        GameObject missile = Instantiate(missilepref, camera.transform.position, camera.transform.localRotation);
        missile.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);
        Rigidbody rb = missile.GetComponent<Rigidbody>();
        rb.AddForce(camera.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
