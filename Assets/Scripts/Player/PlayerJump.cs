using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField, Min(0)] private float _jumpHeight = 3f;
    [SerializeField, Min(1)] private int _jumpCount = 2;

    private Rigidbody _rigidbody;
    private int _jumpCountRemaining;
    private float _jumpForce;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_jumpCountRemaining = _jumpCount;
		_jumpForce = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _rigidbody.velocity.y >= 0 && _jumpCountRemaining --> 0)
		{
			_rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.contacts[0].point.y < transform.position.y)
		{
			_jumpCountRemaining = _jumpCount;
		}
	}
}
