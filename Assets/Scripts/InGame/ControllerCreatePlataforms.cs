using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCreatePlataforms : MonoBehaviour {

	GameObject player;
	GameObject up, down, left, right; 
	List<GameObject> lines;
	Vector3 lastDirection;

	public GameObject linesObjects;

	Vector3 lastLinePosition, nextLinePosition ;


	// Update is called once per frame
	void Start () {
		lines = new List<GameObject>();
		ControllerPopup.Initialize ();
		player = GameObject.FindGameObjectWithTag ("Player");
		StartLines ();
	

//		Instantiate (left);
//		Instantiate (up);
		GameObject instance = Instantiate (right, linesObjects.transform);
		lines.Add (instance);
		lastDirection.z = right.transform.eulerAngles.z; 
		lastLinePosition = new Vector3 (0,0,0);

	}

	void FixedUpdate(){
		for (int i = 0; i < lines.Count; i++) {
			if (lines[i] == null) {
				lines.RemoveAt (i);
				}
			}
			CreateNextLine ();

	}

	void CreateNextLine(){
		int randomDirection = Random.Range(0,100);
		//up
		float distance = 7.9f;
		if (lastDirection.z == 0) { 
			if (randomDirection <= 33){
				InstantiateLines (left, new Vector3(0,distance,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (up, new Vector3(0,distance-1,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (right, new Vector3(0,distance,0));
			}
		}
		//right
		if (lastDirection.z == 270) {
			if (randomDirection <= 33){
				InstantiateLines (up, new Vector3(distance,0,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (right, new Vector3(distance-1,0,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (down, new Vector3(distance,0,0));
			}
		}
		//down
		if (lastDirection.z == 180) {
			if (randomDirection <= 33){
				InstantiateLines (right, new Vector3(0,-distance,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (down, new Vector3(0,-distance+1,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (left, new Vector3(0,-distance,0));
			}
		}
		//left
		if (lastDirection.z == 90) {
			if (randomDirection <= 33){
				InstantiateLines (left, new Vector3(-distance+1,0,0));
			}
			if (randomDirection > 33 && randomDirection <= 67){
				InstantiateLines (down, new Vector3(-distance,0,0));
			}
			if (randomDirection > 67 && randomDirection <= 100){
				InstantiateLines (up, new Vector3(-distance,0,0));
			}
		}
	}

	void InstantiateLines(GameObject line, Vector3 nextPosition){
		if (lines.Count < 3) {
		nextLinePosition = lastLinePosition+nextPosition;
		Quaternion angulo = line.transform.localRotation;
//			orientacion, position, roti
			GameObject lineInstance = Instantiate (line, nextLinePosition, angulo,linesObjects.transform);		
			lines.Add (lineInstance);
			transform.position = nextLinePosition;
			lastLinePosition = nextLinePosition;
			lastDirection.z = line.transform.eulerAngles.z;
		}
	}

	void StartLines(){
		up = (GameObject)Resources.Load ("Prefabs/LinhaUp");;
		down = (GameObject)Resources.Load ("Prefabs/LinhaDown");;
		left = (GameObject)Resources.Load ("Prefabs/LinhaLeft");;
		right = (GameObject)Resources.Load ("Prefabs/LinhaRight");;
	}


}
