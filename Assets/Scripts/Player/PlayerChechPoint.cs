using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerChechPoint : MonoBehaviour
{
    private Vector3 _lastCheckPoint;
    private HashSet<CheckPoint> _checkPoints = new();
    private Health _health;
	private Rigidbody _rigidbody;

    private void Awake()
    {
		_health = GetComponent<Health>();
		_rigidbody = GetComponent<Rigidbody>();
		_lastCheckPoint = transform.position;
	}

	private void OnEnable()
	{
		_health.HealthReduced += OnHealthReduced;
	}

	private void OnDisable()
	{
		_health.HealthReduced -= OnHealthReduced;
	}

	private void OnHealthReduced(int health)
	{
		if (health > 0)
		{
			Teleport();
		}
	}

	public void Teleport()
	{
		transform.position = _lastCheckPoint;
		_rigidbody.velocity = Vector3.zero;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out CheckPoint checkPoint))
		{
			if (_checkPoints.Contains(checkPoint))
				return;

			_lastCheckPoint = checkPoint.Point;
			checkPoint.Interact();
			_checkPoints.Add(checkPoint);
		}
	}
}
