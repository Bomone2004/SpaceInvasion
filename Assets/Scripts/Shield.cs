using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (!enabled) return;

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
