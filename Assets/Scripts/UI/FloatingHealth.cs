using UnityEngine;

public class FloatingHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private MeshRenderer[] _heartMeshes;
    [SerializeField] private Material _fullHeartMaterial;
    [SerializeField] private Material _emptyHeartMaterial;

	private void Start()
	{
		UpdateHearts(_health.CurrentHealth);
	}

	private void OnEnable()
	{
		_health.HealthChanged += UpdateHearts;
	}

	private void OnDisable()
	{
		_health.HealthChanged -= UpdateHearts;
	}

	private void LateUpdate()
	{	
		Vector3 rotation = transform.parent.rotation.eulerAngles;
		rotation.x = 0;
		rotation.z = 0;
		transform.rotation = Quaternion.Euler(rotation);
	}

	private void UpdateHearts(int currentHealth)
	{
		for (int i = 0; i < _heartMeshes.Length; i++)
		{
			_heartMeshes[i].material = i < currentHealth
										? _fullHeartMaterial
										: _emptyHeartMaterial;
		}
	}
}
