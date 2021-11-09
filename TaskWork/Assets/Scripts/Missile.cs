using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float force = 10000f;
    private float destroyRadius = 3f;
    private float impulseRadius = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        MissileClears();

        if (collision.gameObject.tag != "Target")
            return;

        DisableKinematic();
        Explode();

        if (!TargetGenerator.instance.IsInvoking("Respawn"))
            TargetGenerator.instance.Invoke("Respawn", 8);
    }

    private void Explode()
    {
        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, impulseRadius);
        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, destroyRadius);

        for (int i = 0; i < collidersToMove.Length; i++)
        {
            if (collidersToMove[i].attachedRigidbody != null)
            {
                if (System.Array.Exists(collidersToDestroy, x => collidersToMove[i] == x))
                    Destroy(collidersToMove[i].gameObject);
                else
                    collidersToMove[i].attachedRigidbody.AddExplosionForce(force, transform.position, impulseRadius);
            }
        }
        #region default implementation
        // Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, destroyRadius);

        // foreach (Collider nearbyObject in collidersToDestroy)
        // {
        //     Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //     if (rb != null)
        //     {
        //         rb.AddExplosionForce(force, transform.position, destroyRadius);
        //         Destroy(nearbyObject.gameObject);
        //     }
        // }

        // Collider[] collidersToMove = Physics.OverlapSphere(transform.position, impulseRadius);

        // foreach (Collider nearbyObject in collidersToMove)
        // {
        //     Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
        //     if (rb != null)
        //     {
        //         rb.AddExplosionForce(force, transform.position, impulseRadius);
        //         Destroy(nearbyObject.gameObject, 5f);
        //     }
        // }
#endregion
    }

    private void DisableKinematic()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in targets)
        {
            target.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(target.gameObject, 7f);
        }
    }

    private void MissileClears()
    {
        Missile[] missiles = FindObjectsOfType<Missile>();

        foreach (Missile missile in missiles)
        {
            Destroy(this.gameObject, 10);
        }
    }
}
