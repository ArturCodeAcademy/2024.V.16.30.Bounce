using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public event Action OnDashMoveUsed;
    [field: SerializeField, Min(0)] public float DashImpulseCooldown = 1f;

    [SerializeField, Min(0)] private float _movementForce = 10f;
    [SerializeField, Min(0)] private float _dashImpulse = 20f;
    [SerializeField, Min(0)] private float _normalDrag = 0f;
    [SerializeField,Min(0)] private float _brakeDarag = 2.5f;

    [Space(3)]
    [SerializeField] private Transform _cameraTransform;

    private Rigidbody _rigidbody;
    private float _dashImpulseTimer = 0;
    private Vector3 _movementDirection;

    private void Awake()
    {
		_rigidbody = GetComponent<Rigidbody>();
	}

    private void Update()
    {
		_movementDirection = new (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _movementDirection = _cameraTransform.TransformDirection(_movementDirection).normalized;

        if (_dashImpulseTimer > 0)
			_dashImpulseTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && _dashImpulseTimer <= 0)
        {
            Vector3 dashDirection = _cameraTransform.TransformDirection(Vector3.forward);
            dashDirection.y = 0;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(dashDirection * _dashImpulse, ForceMode.Impulse);
            _dashImpulseTimer = DashImpulseCooldown;
            OnDashMoveUsed?.Invoke();
        }

		_rigidbody.drag = Input.GetKey(KeyCode.LeftControl) ? _brakeDarag : _normalDrag;
	}

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_movementDirection * _movementForce, ForceMode.Force);
    }
}
