using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDestroy : MonoBehaviour {
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")){
			Destroy(gameObject);
		}
	}
}
