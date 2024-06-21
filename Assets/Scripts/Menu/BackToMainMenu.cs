using UnityEngine;

public class BackToMainMenu : MonoBehaviour
{
    private const int MAIN_MENU_SCENE_INDEX = 0;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			LoadMainMenu();
		}
	}

	public void LoadMainMenu()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene(MAIN_MENU_SCENE_INDEX);
	}
}
