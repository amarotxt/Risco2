using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public float Points;
	public float acceleration;
	public float speed;
	public Vector2 direction;

	public float minSwipeLength = 5f;
	// Swipe
	public Vector2 firstPressPos;
	public Vector2 secondPressPos;
	public Vector2 currentSwipe;
	public Vector2 firstClickPos;
	public Vector2 secondClickPos;

}
