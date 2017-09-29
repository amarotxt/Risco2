using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersInGame : MonoBehaviour {
	public GameObject pauseButton;
	public GameObject playButton;
	public GameObject player;

	public void PauseGame(AudioSource song){
		pauseButton.SetActive (false);
		playButton.SetActive (true);
		player.GetComponent<ControllerPlayer> ().player.pauseGame = true;
		Time.timeScale = 0;
		song.Pause();

	}
	public void PlayGame(AudioSource song){
		pauseButton.SetActive (true);
		playButton.SetActive (false);
		player.GetComponent<ControllerPlayer> ().player.pauseGame = false;
		song.Play();
		Time.timeScale = 1;
	
	}
}
