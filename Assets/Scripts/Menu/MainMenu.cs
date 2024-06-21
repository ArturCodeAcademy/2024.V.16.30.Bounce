using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private RectTransform _content;
	[SerializeField] private Button _buttonPrefab;

	private void Start()
	{
		int levelCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 1; i < levelCount; i++)
        {
			var button = Instantiate(_buttonPrefab, _content);
			TMP_Text levelText = button.transform.GetChild(0).GetComponent<TMP_Text>();
			levelText.text = $"Level {i}";

			TMP_Text recordText = button.transform.GetChild(1).GetComponent<TMP_Text>();
			string sceneName = SceneUtility.GetScenePathByBuildIndex(i) + "_record";
			int record = PlayerPrefs.GetInt(sceneName, 0);
			if (record > 0)
				recordText.text = $"Best time:\n{record/60:00}:{record%60:00}";
			else
				recordText.text = "No record";

			int levelIndex = i;
			button.onClick.AddListener(() => SceneManager.LoadScene(levelIndex));

			button.gameObject.SetActive(true);
		}
    } 

	public void ExitGame()
    {
		Application.Quit();
	}
}
