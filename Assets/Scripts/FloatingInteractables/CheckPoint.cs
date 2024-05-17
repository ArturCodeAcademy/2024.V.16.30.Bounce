using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent Use;

    public Vector3 Point => transform.position + _offset;
    [SerializeField] private Vector3 _offset;

    public void Interact()
    {
		Use.Invoke();
	}

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(Point, 0.5f);
	}

#endif
}
