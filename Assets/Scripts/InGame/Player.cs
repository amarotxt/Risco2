using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	public float Points;
	public float acceleration;
	public float speed;
	public int directionX;
	public int directionY;


	public void SetDirection( int directionX, int directionY){
		this.directionX = directionX;
		this.directionY = directionY;

	}
}
