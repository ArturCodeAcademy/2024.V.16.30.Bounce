using UnityEngine;

public class PlayerScoreCollector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
        if (other.TryGetComponent(out Score score))
        {
            int value = score.TakeScore();
            ScoreManager.Instance.AddScore(value);
        }
    }
}
