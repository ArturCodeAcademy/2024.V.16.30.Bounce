using UnityEngine;

public class Damager : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out Health health))
		{
			health.Hit();
		}
	}
}
