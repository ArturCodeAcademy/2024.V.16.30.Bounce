using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelPanelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private Timer _timer;

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void SetText()
    {
		_timeText.text = $"Current time: {_timer.Minute:00}:{_timer.Second:00}";
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
		string sceneName = SceneUtility.GetScenePathByBuildIndex(buildIndex) + "_record";
		int record = PlayerPrefs.GetInt(sceneName, 0);	
        if (record == 0)
        {
			_recordText.text = "Record: --:--";
		}
		else
        {
			_recordText.text = $"Record: {record / 60:00}:{record % 60:00}";
		}
	}
}
