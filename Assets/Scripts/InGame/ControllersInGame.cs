using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersInGame : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject playButton;
	public GameObject player;

	public void PauseGame(){
		pauseButton.SetActive (false);
		playButton.SetActive (true);
		player.GetComponent<ControllerPlayer> ().player.pauseGame = true;
		Time.timeScale = 0;
	}
	public void PlayGame(){
		pauseButton.SetActive (true);
		playButton.SetActive (false);
		player.GetComponent<ControllerPlayer> ().player.pauseGame = false;
		Time.timeScale = 1;
	}
}
