using UnityEngine;

public class Damager : MonoBehaviour
{
	[SerializeField] private bool _destroyOnHit = true;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out Health health))
		{
			health.Hit();

			if (_destroyOnHit)
				Destroy(gameObject);
		}
	}
}
