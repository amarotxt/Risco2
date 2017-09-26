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
	public GameObject painelTutorial;
	int parentPosition;

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
		SceneManager.LoadScene (1);
	}

	public void OpenTutorial (){
		painelTutorial.SetActive (true);
	}
	public void CloseTutorial(){
		painelTutorial.SetActive (false);
	}

	public void NextPainelTuroial(){
		parentPosition += 1;
		if (parentPosition >= 2 ) {
			parentPosition = 2;
		} 
		DesativarPaineisTutorial ();
		painelTutorial.transform.GetChild (parentPosition).gameObject.SetActive (true);
	}
	public void BackPainelTuroial(){
		parentPosition -= 1;
		if (parentPosition <= 0 ) {
			parentPosition = 0;
		}
		DesativarPaineisTutorial ();
		painelTutorial.transform.GetChild (parentPosition).gameObject.SetActive (true);
	}
	void DesativarPaineisTutorial(){
		for(int i=0;i<=2; i++){
			painelTutorial.transform.GetChild (i).gameObject.SetActive (false);
		}
	}
}
