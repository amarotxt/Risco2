using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public float points;
	public int bonus;
	public float aumento = 0.5f;
	public float acceleration;

//	private float speed;
	// follow

	public Vector2 direction;
	public Coroutine gameOverRoutine;

	// Swipe
	public float minSwipeLength = 5f;
	public Vector2 firstPressPos;
	public Vector2 secondPressPos;
	public Vector2 currentSwipe;
	public Vector2 firstClickPos;
	public Vector2 secondClickPos;

	public bool inLine;
	public bool pauseGame;
//	public float Points{get;set;}
//	public int Bonus{get;set;}
//	public float Aumento{get;set;}
//	public float Acceleration{get;set;}
////	public float Speed{get;set;}
//	public Vector2 Direction{get;set;}
//	public Coroutine  GameOverRoutine{get;set;}
//	public float  MinSwipeLength{get;set;}
//	public Vector2 FirstPressPos{ get; set;}
//	public Vector2 SecondPressPos{ get; set;}
//	public Vector2 CurrentSwipe { get; set;}
//	public Vector2 FirstClickPos { get; set;}
//	public Vector2 SecondClickPos { get; set;}
//	public bool InLine { get; set;}

}
