using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private string _format = "Score: {0:000000}";

    public void UpdateScore(int score)
    {
		_scoreText.text = string.Format(_format, score);
	}
}
