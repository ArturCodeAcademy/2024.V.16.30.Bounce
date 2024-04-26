using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [field: SerializeField] public int ScoreValue { get; private set; }
	[SerializeField] private bool _destroyOnTake = true;

	public UnityEvent ScoreTaken;

	private void Awake()
	{
		ScoreTaken ??= new UnityEvent();
	}

	public int TakeScore()
    {
		if (_destroyOnTake)
			Destroy(gameObject);

		ScoreTaken?.Invoke();
		return ScoreValue;
	}
}
