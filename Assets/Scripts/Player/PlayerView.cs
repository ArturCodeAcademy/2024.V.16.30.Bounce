using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Transform _target;
	[SerializeField] private Camera _camera;

	[Space(3)]
	[SerializeField] private float _sensitivity = 10f;
	[SerializeField] private float _maxXRotation = 75f;
	[SerializeField] private float _minXRotation = -30f;

	[Space(3)]
	[SerializeField, Min(0)] private float _minDistance = 5f;
	[SerializeField, Min(0)] private float _maxDistance = 10f;
	[SerializeField, Min(0)] private float _zoomSpeed = 1f;

	private float _xRotation = 0f;
	private float _yRotation = 0f;

	private float _distanceToTarget;

	private void Awake()
	{
		_distanceToTarget = -_camera.transform.position.z;
	}

	private void Update()
	{
		transform.position = _target.position;

		_yRotation += Input.GetAxis("Mouse X") * _sensitivity;
		_xRotation -= Input.GetAxis("Mouse Y") * _sensitivity;
		_xRotation = Mathf.Clamp(_xRotation, _minXRotation, _maxXRotation);

		transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);

		if (Input.mouseScrollDelta.y != 0)
		{
			_distanceToTarget = Mathf.Clamp(_distanceToTarget - Input.mouseScrollDelta.y * _zoomSpeed, _minDistance, _maxDistance);
			_camera.transform.localPosition = Vector3.back * _distanceToTarget;
		}
	}
}
