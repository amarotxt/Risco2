using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerButtons : MonoBehaviour {
	GameObject playerMoviments;

	public void NewGame(){
		playerMoviments = GameObject.Find ("PlayerMoviments");
		if (playerMoviments != null){
			Destroy (playerMoviments);
		}
		SceneManager.LoadScene (0);
	}
}
