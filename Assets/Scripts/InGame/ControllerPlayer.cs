using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Swipe { None, Up, Down, Left, Right };

public class ControllerPlayer : MonoBehaviour {
	public Player player;
	public Text pointsText;
	public Text bonusText;

	public GameObject linesObjects;
	GameObject playerMoviments;
	PlayerMoviments savePositions;

	public static Swipe swipeDirection;

	// Use this for initialization
	void Start () {
		playerMoviments = GameObject.Find ("PlayerMoviments");
		savePositions = playerMoviments.GetComponent<PlayerMoviments>();
		player = new Player ();
		player.direction =new Vector2(1,0);
		player.inLine = true;
		player.acceleration = 2;
		player.points = 0;
		player.bonus = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CalcularPontuacao ();
		CalcularVelocidade ();
		pointsText.text = player.points.ToString ("00");
		if (player.direction.x == 1 && player.direction.y == 0 ){
			transform.Translate (player.acceleration*Time.deltaTime*Vector3.right);
		}else if (player.direction.x == -1 && player.direction.y == 0 ){
			transform.Translate (player.acceleration*Time.deltaTime*Vector3.left);
		}else if (player.direction.x == 0 && player.direction.y == 1 ){
			transform.Translate (player.acceleration*Time.deltaTime*Vector3.up);
		}else if (player.direction.x == 0 && player.direction.y == -1 ){


			transform.Translate (player.acceleration*Time.deltaTime*Vector3.down);
		}
		DetectSwipe ();


	}
	IEnumerator GameOverRoutine(){
		yield return new WaitForSeconds (0.5f);
		CheckGameOver ();
	}

	public void CheckGameOver (){

		if (!player.inLine) {
			SetRecords ();
			savePositions.SavePositionsPlayer(transform.position);
			DontDestroyOnLoad (playerMoviments);
			SceneManager.LoadScene (0);
		}
	}

	void SetRecords(){
		PlayerPrefs.SetFloat ("points", player.points);

		if (player.points > PlayerPrefs.GetFloat("record")){
			PlayerPrefs.SetFloat ("record", player.points);
		}
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Line")){
			player.inLine = false;
			if (player.gameOverRoutine != null){
				StopCoroutine (player.gameOverRoutine);
			}
			player.gameOverRoutine = StartCoroutine("GameOverRoutine");
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.CompareTag("Line")){
			player.inLine = true;
		}
	}
	void  CalcularPontuacao(){
		if (!player.pauseGame){ 
		player.points = player.aumento + player.points;
		}
//		if (player.points > PlayerPrefs.GetFloat ("Recorde")){
//			if (podeTocarRecord && PlayerPrefs.GetFloat("Recorde") != 0) {
//				ControladorAudio._instance.StartCoroutine("playRecord");
//				podeTocarRecord = false;
//			}
//		}
	}
	public void CalcularVelocidade(){
			player.acceleration = (float)Math.Log (player.points, 2) ;
	}

	public void DetectSwipe (){
		if (Input.touches.Length > 0) {

			Touch t = Input.GetTouch (0);
			if (t.phase == TouchPhase.Began) {

				player.firstPressPos = new Vector2 (t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Moved) {

				player.secondPressPos = new Vector2 (t.position.x, t.position.y);
				player.currentSwipe = new Vector3 (player.secondPressPos.x - player.firstPressPos.x, player.secondPressPos.y - player.firstPressPos.y);
				if (player.currentSwipe.magnitude < player.minSwipeLength) {
					swipeDirection = Swipe.None;
					return;
				}

				player.currentSwipe.Normalize ();
				//Swipe directional check
				if (player.direction.x != 0) { 
					// Swipe up
					if (player.currentSwipe.y >  0.4  && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2 (0, 1);
					}
					// Swipe down
					else if (player.currentSwipe.y <  -0.4  && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2 (0, -1);
					}
				}
				if (player.direction.y != 0) {
					// Swipe left
					if (player.currentSwipe.x < -0.4 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2(-1,0);				
					}
					// Swipe right
					else if (player.currentSwipe.x > 0.4 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2(1,0);				
					}
				}
			} 
		}else {
			if (Input.GetMouseButtonDown (0)) {
				player.firstClickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			} else {
				swipeDirection = Swipe.None;
			}

			if (Input.GetMouseButton (0)) {
				player.secondClickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				player.currentSwipe = new Vector3 (player.secondClickPos.x - player.firstClickPos.x, player.secondClickPos.y - player.firstClickPos.y);
				//		
				player.currentSwipe.Normalize ();
				//Swipe directional check
				if (player.direction.x != 0) { 
					// Swipe up
					if (player.currentSwipe.y > 0.4 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2 (0, 1);

					}
					// Swipe down
					else if (player.currentSwipe.y < -0.4 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2 (0, -1);
					}
				}
				if (player.direction.y != 0) {
					// Swipe left
					if (player.currentSwipe.x < -0.4 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						CheckBonusPoints ();
						player.direction = new Vector2 (-1, 0);				
					}
					// Swipe right
					else if (player.currentSwipe.x > 0.4 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {

						CheckBonusPoints ();
						player.direction = new Vector2 (1, 0);				
					}
				}
			}
		}
	}

	void CheckBonusPoints(){
		float distanceNextLine = Vector3.Distance (linesObjects.transform.GetChild(1).transform.position, transform.position);
// 		set bonus
		if (player.bonus > PlayerPrefs.GetFloat("bonus")){
			PlayerPrefs.SetFloat ("bonus", player.bonus);
		}
//		save Positions player
		savePositions.SavePositionsPlayer (transform.position);

		if( distanceNextLine >= 0.5){
//			Debug.Log ("Bad"+distanceNextLine);
			ControllerPopup.CreatingDamagePopupText("Bad!", transform);
			player.aumento = 0.5f;
			player.bonus = 0;
			bonusText.text = player.bonus.ToString()+"x";
		}
		if( distanceNextLine < 0.5 && distanceNextLine >= 0.2f ){
			//			Debug.Log ("Good"+distanceNextLine);
			ControllerPopup.CreatingDamagePopupText("Good!", transform);
			player.aumento += 0.5f;
			player.bonus += 1;
			bonusText.text = player.bonus.ToString()+"x";

		}
		if( distanceNextLine < 0.2f && distanceNextLine >= 0 ){
			//			Debug.Log ("Perfect"+distanceNextLine);
			ControllerPopup.CreatingDamagePopupText("Perfect!", transform);
			player.aumento += 1f;
			player.bonus += 2;
			bonusText.text = player.bonus.ToString()+"x";

		}

	}

}
