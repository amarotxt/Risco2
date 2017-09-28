using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersInGame : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject playButton;
	public void PauseGame(){
		pauseButton.SetActive (false);
		playButton.SetActive (true);
		Time.timeScale = 0;
	}
	public void PlayGame(){
		pauseButton.SetActive (true);
		playButton.SetActive (false);
		Time.timeScale = 1;
	}
}
