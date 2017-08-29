using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Swipe { None, Up, Down, Left, Right };

public class ControllerPlayer : MonoBehaviour {
	Player player;

	public static Swipe swipeDirection;

	// Use this for initialization
	void Start () {
		player = new Player ();
		player.direction =new Vector2(1,0);

		player.acceleration = 2;

	}
	
	// Update is called once per frame
	void Update () {
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

	public void DetectSwipe (){
		if (Input.touches.Length > 0) {
			
			Touch t = Input.GetTouch (0);
			if (t.phase == TouchPhase.Began) {

				player.firstPressPos = new Vector2 (t.position.x, t.position.y);
			}
			if (t.phase == TouchPhase.Ended) {
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
					if (player.currentSwipe.y > 0 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						player.direction = new Vector2 (0, 1);
					}
					// Swipe down
					else if (player.currentSwipe.y < 0 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						player.direction = new Vector2 (0, -1);
					}
				}
				if (player.direction.y != 0) {
					// Swipe left
					if (player.currentSwipe.x < 0 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						player.direction = new Vector2(-1,0);				
					}
					// Swipe right
					else if (player.currentSwipe.x > 0 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						player.direction = new Vector2(1,0);				
					}
				}

//		
			} 
		}else {
				if (Input.GetMouseButtonDown (0)) {
					player.firstClickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
				} else {
					swipeDirection = Swipe.None;
				}
		
				if (Input.GetMouseButtonUp (0)) {
					player.secondClickPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					player.currentSwipe = new Vector3 (player.secondClickPos.x - player.firstClickPos.x, player.secondClickPos.y - player.firstClickPos.y);
//		
					player.currentSwipe.Normalize ();
					//Swipe directional check
				if (player.direction.x != 0) { 
					// Swipe up
					if (player.currentSwipe.y > 0 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						player.direction = new Vector2 (0, 1);
					}
					// Swipe down
					else if (player.currentSwipe.y < 0 && player.currentSwipe.x > -0.5f && player.currentSwipe.x < 0.5f) {
						player.direction = new Vector2 (0, -1);
					}
				}
				if (player.direction.y != 0) {
					// Swipe left
					if (player.currentSwipe.x < 0 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						player.direction = new Vector2 (-1, 0);				
					}
					// Swipe right
					else if (player.currentSwipe.x > 0 && player.currentSwipe.y > -0.5f && player.currentSwipe.y < 0.5f) {
						player.direction = new Vector2 (1, 0);				
					}
				}

				}
			}

	}
}
