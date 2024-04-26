using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

	public UnityEvent<int> ScoreChanged;

    public int Score { get; private set; }

    private void Awake()
    {
		if (Instance is not null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		ScoreChanged ??= new UnityEvent<int>();
	}

	public void AddScore(int score)
	{
		Score += score;
		ScoreChanged?.Invoke(Score);
	}

	public void ResetScore()
	{
		Score = 0;
	}
}
