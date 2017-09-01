using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	GameObject playerMoviments;
	PlayerMoviments savePositions;
	List<Vector3> positionsPlayer;
	int i;
	float speed;
	void Start(){
		i = 0;
		speed = 10f;
		playerMoviments = GameObject.Find ("PlayerMoviments");
		savePositions = playerMoviments.GetComponent<PlayerMoviments>();
		positionsPlayer = savePositions.PositionsMoviments;
		Debug.Log (positionsPlayer.Count);
	}
	
//	 Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, positionsPlayer[i],Time.deltaTime*speed);
		if (transform.position == positionsPlayer[i] &&  i < positionsPlayer.Count-1){
			Debug.Log ("teste");
			i += 1;
			speed += 5f;
		}
	}
}
