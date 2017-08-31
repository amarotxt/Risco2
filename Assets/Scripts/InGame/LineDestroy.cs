using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDestroy : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Player")){
			Destroy(gameObject,0.5f);
		}
	}
//	private IEnumerator DestroiLines()
//	{
//		PlayAnimation(GlobalSettings.animDeath1, WrapeMode.ClampForever);
//		yield return new WaitForSeconds(gameObject, GlobalSettings.animDeath1.length);
//		Destroy(gameObject);
//	}
}
