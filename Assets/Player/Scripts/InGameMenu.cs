using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour 
{
	public bool isOnEscapeScreen;
	public GameObject GameOverCanvas;
	// Use this for initialization
	void Start () {
		isOnEscapeScreen = false;
		//GameOverCanvas = GameObject.Find("UI Managment/GameOverCanvas");
	}
	
	// Update is called once per frame
	void Update () {
		menuopen();
	}

	void menuopen()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && !isOnEscapeScreen)
		{
			isOnEscapeScreen = true;
			Time.timeScale = 0;
			GameOverCanvas.SetActive(true);
			Cursor.visible = true;
		}
		else if(Input.GetKeyDown(KeyCode.Escape) && isOnEscapeScreen)
		{
			isOnEscapeScreen = false;
			Time.timeScale = 1;
			GameOverCanvas.SetActive(false);
			Cursor.visible = false;
		}
	}
}
