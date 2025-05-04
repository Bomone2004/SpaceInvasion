using UnityEngine;

public class ShieldUp : MonoBehaviour
{
    Rigidbody rb;

    float physicSpeed = 50;

    Vector3 movementDirection = Vector3.down;

    void Start()
    {
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();

        }


        rb.useGravity = false;
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Extrapolate;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementDirection * physicSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!enabled) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            //Self destruct bullet
            Destroy(gameObject);
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;

        if (other.gameObject.CompareTag("Player"))
        {
            //Self destruct bullet
            Destroy(gameObject);
            enabled = false;
        }
    }
}
