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
	}
	#endregion

	[SerializeField] private GameObject canvasMenu = null;

	[SerializeField] private GameObject ingameMenu = null;
	[SerializeField] private GameObject questlog = null;
	[SerializeField] private GameObject inventorySystem = null;

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

	public void OnResumeClick()
	{
		ingameMenu.SetActive(false);
		questlog.SetActive(true);
		BasicMovement.Instance.CanWalk = true;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			BasicMovement.Instance.CanWalk = false;
			ingameMenu.SetActive(true);
			questlog.SetActive(false);
			inventorySystem.SetActive(false);
		}
	}
}