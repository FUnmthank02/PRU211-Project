using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	

	public static bool isGamePaused = false;
	public GameObject PauseGameUI;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (isGamePaused)
			{
				Resume();
			}
			else
			{

				Pause();
			}
		}
	}

	public void Resume()
	{
		PauseGameUI.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
	}

	public void Pause()
	{
		Debug.Log("Click");
		PauseGameUI.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
	}

	public void LoadMenu()
	{
		Debug.Log("load");
		Time.timeScale = 1f;
		SceneManager.LoadScene(1);
	}

	public void Quit()
	{

		Application.Quit();
	}

	public void Restart()
	{
		Debug.Log("restart");
		SceneManager.LoadScene("Map1");
		Time.timeScale = 1f;
		PauseGameUI.SetActive(false);
	}

}
