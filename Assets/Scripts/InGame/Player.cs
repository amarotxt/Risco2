using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public float points;
	public int bonus;
	public float aumento = 0.5f;

	public float acceleration;
	public float speed;
	public Vector2 direction;
	public Coroutine gameOverRoutine;
	public float minSwipeLength = 5f;
	// Swipe
	public Vector2 firstPressPos;
	public Vector2 secondPressPos;
	public Vector2 currentSwipe;
	public Vector2 firstClickPos;
	public Vector2 secondClickPos;

	public bool inLine;

}
