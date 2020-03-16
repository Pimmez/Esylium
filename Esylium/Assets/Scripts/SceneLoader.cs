using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	#region Singleton
	public static SceneLoader instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More then one instance of inventory is active in the scene");
			return;
		}
		instance = this;

		GameObject[] objs = GameObject.FindGameObjectsWithTag(Tags.GAMECONTROLLER);

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
	#endregion

	public void StartGame(int _sceneIndex)
	{
		SceneManager.LoadScene(_sceneIndex);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void SwitchToScene(int _sceneIndex)
	{
		SceneManager.LoadSceneAsync(_sceneIndex);
	}
}