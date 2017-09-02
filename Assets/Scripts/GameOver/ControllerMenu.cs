using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerMenu : MonoBehaviour {
	GameObject playerMoviments;
	Text pointsValue;
	Text bestPointsValue;
	Text bonusValue;

	void Start(){
		bestPointsValue = GameObject.Find ("BestPointsValue").GetComponent<Text> ();
		pointsValue = GameObject.Find ("PointsValue").GetComponent<Text> ();
		bonusValue = GameObject.Find ("BestBonusValue").GetComponent<Text> ();
	
		bestPointsValue.text = PlayerPrefs.GetFloat("record").ToString("00");
		pointsValue.text = PlayerPrefs.GetFloat("points").ToString("00");
		bonusValue.text = PlayerPrefs.GetFloat("bonus").ToString("00");

	}

	public void NewGame(){
		playerMoviments = GameObject.Find ("PlayerMoviments");
		if (playerMoviments != null){
			Destroy (playerMoviments);
		}
		SceneManager.LoadScene (0);
	}
}
