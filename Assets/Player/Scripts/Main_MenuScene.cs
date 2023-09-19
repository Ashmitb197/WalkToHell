using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_MenuScene : MonoBehaviour {
	
	// Update is called once per frame
	public GameObject MainmenuOptions;
	public GameObject optionsMenu;
	public AudioClip[] sounds;
	public AudioSource source;


	public void StartGame()
	{
		source.clip = sounds[2];
		source.Play();
		SceneManager.LoadScene("TestScene");
		
	}
	public void Options()
	{
		MainmenuOptions.SetActive(false);
		optionsMenu.SetActive(true);
		source.clip = sounds[2];
		source.Play();
	}
	public void Back()
	{
		MainmenuOptions.SetActive(true);
		optionsMenu.SetActive(false);
		source.clip = sounds[2];
		source.Play();		
	}
	public void Fullscreen(bool isFullScreen)
	{
		Screen.fullScreen = isFullScreen;
		//Screen.SetResolution(1366,768, isFullScreen);
		source.clip = sounds[0];
		source.Play();
	}
	public void Quit()
	{
		Application.Quit();
		source.clip = sounds[1];
		source.Play();
	}
}
