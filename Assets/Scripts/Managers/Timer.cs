using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public UnityEvent OnFinished;

    public int Minute => (int)_seconds / 60;
    public int Second => (int)_seconds % 60;
	public bool IsRunning { get; private set; }

    private float _seconds;

	private void Start()
	{
		IsRunning = true;
		_seconds = 0;
	}

	private void Update()
    {
		_seconds += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlayerMovement _))
		{
			IsRunning = false;
			OnFinished?.Invoke();
		}
	}

	private void OnDestroy()
	{
		int buildIndex = SceneManager.GetActiveScene().buildIndex;
		string sceneName = SceneUtility.GetScenePathByBuildIndex(buildIndex) + "_record";
		int record = PlayerPrefs.GetInt(sceneName, 0);
		if (record == 0 || record > _seconds)
			PlayerPrefs.SetInt(sceneName, (int)_seconds);
	}
}
