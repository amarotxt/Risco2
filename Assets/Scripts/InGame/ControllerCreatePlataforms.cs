using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCreatePlataforms : MonoBehaviour {

	GameObject player;
	GameObject up, down, left, right; 

	List<GameObject> lines;
	Vector3 lastDirection;

	Vector3 positionPlayer, lastLinePosition, nextLinePosition ;
		
	// Update is called once per frame
	void Start () {
		lines = new List<GameObject>();

		player = GameObject.FindGameObjectWithTag ("Player");
		StartLines ();
	

//		Instantiate (left);
//		Instantiate (up);
		Instantiate (right);
		lastDirection.z = right.transform.eulerAngles.z; 
		lastLinePosition = new Vector3 (0,0,0);
	}

	void FixedUpdate(){
//		if (lines.Count <= 10){
			CreateNextLine ();
//		}
	}
	void CreateNextLine(){
		int randomDirection = Random.Range(0,100);
		//up

		if (lastDirection.z == 0) {
			if (randomDirection <= 33){
				InstantiateLines (left, new Vector3(0,4,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (up, new Vector3(0,4,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (right, new Vector3(0,4,0));
			}
		}
		//right
		if (lastDirection.z == 270) {
			if (randomDirection <= 33){
				InstantiateLines (up, new Vector3(4,0,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (right, new Vector3(4,0,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (down, new Vector3(4,0,0));
			}
		}
		//down
		if (lastDirection.z == 180) {
			if (randomDirection <= 33){
				InstantiateLines (right, new Vector3(0,-4,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (down, new Vector3(0,-4,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (left, new Vector3(0,-4,0));
			}
		}
		//left
		if (lastDirection.z == 90) {
			if (randomDirection <= 33){
				InstantiateLines (left, new Vector3(-4,0,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (down, new Vector3(-4,0,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (left, new Vector3(-4,0,0));
			}
		}
	}

	void InstantiateLines(GameObject line, Vector3 nextPosition){
		nextLinePosition = lastLinePosition+nextPosition;
		Debug.Log ("nextpoint: "+nextPosition);
		Debug.Log ("next Position: "+nextLinePosition);
		Quaternion angulo = line.transform.localRotation;
		Instantiate (line,nextLinePosition, angulo);

		lastLinePosition = nextLinePosition;
		lastDirection.z = line.transform.eulerAngles.z;
	}

	void StartLines(){
		up = (GameObject)Resources.Load ("Prefabs/LinhaUp");;
		down = (GameObject)Resources.Load ("Prefabs/LinhaDown");;
		left = (GameObject)Resources.Load ("Prefabs/LinhaLeft");;
		right = (GameObject)Resources.Load ("Prefabs/LinhaRight");;

//		Debug.Log(right.transform.eulerAngles.z);
//		Debug.Log(up.transform.eulerAngles.z);
//		Debug.Log(down.transform.eulerAngles.z);
//		Debug.Log(left.transform.eulerAngles.z);
	}


}
