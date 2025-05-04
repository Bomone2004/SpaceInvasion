using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerDestroyOnHit : MonoBehaviour
{
	GameManager manager;
	
	public static Action OnPlayerDestroyed;

	PlayerManager playerManager;

	public PlayerManager PlayerManager { get => playerManager; set => playerManager = value; }

	public GameManager Manager { get => manager; set => manager = value; }

    //public GameManager Manager => manager;
    public void OnCollisionEnter(Collision collision)
	{
		if (!enabled) return;


        if (collision.gameObject.CompareTag("EnemyBullet")) {

			Debug.Log("Hit by Enemy bullet", this);

			//GetComponentInParent<PlayerManager>().enabled = false;
			//GetComponentInParent<MeshRenderer>().enabled = false;

			OnPlayerDestroyed?.Invoke();
			
			Destroy(gameObject,2);

			bool first = true;

			foreach (Transform t in transform) {

				Debug.Log(t.name);

				if (first) {
					first = false;
					continue;
				}				
				t.gameObject.SetActive(true);

				Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
				rb.AddExplosionForce(20, t.transform.position, 100,0,ForceMode.Impulse);
			}

			Manager.GameOver();

			enabled = false;
		}
        else if (collision.gameObject.CompareTag("SpeedUp"))
        {
			PlayerManager.speed *= 1.5f;
        }
        else if (collision.gameObject.CompareTag("ShieldUp"))
        {
			PlayerManager.shield.SetActive(true);
        }
    }
}
