using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private Timer _timer;

	private void Start()
	{
		_timerText.text = "00:00";
	}

	private void LateUpdate()
	{
		if (_timer.IsRunning)
		{
			_timerText.text = $"{_timer.Minute:00}:{_timer.Second:00}";
		}
	}
}
