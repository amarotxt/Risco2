using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPopup : MonoBehaviour {

	private static PopUp popUp;
	private static GameObject canvasDamage;

	// Use this for initialization
	public static void Initialize () {
		canvasDamage = GameObject.Find ("Canvas");

		if(!popUp){
			popUp = Resources.Load<PopUp> ("Prefabs/PopUpsText/PopUpTextParent");

		}
	}

	// Update is called once per frame
	public static void CreatingDamagePopupText (string text, Transform location) {
		PopUp instance = Instantiate (popUp);
		Vector2 positionDamagePopup = Camera.main.WorldToScreenPoint (location.position);
		positionDamagePopup.x += 25;
		instance.transform.SetParent (canvasDamage.transform, false);
		instance.transform.position = positionDamagePopup;
		instance.SetText (text);
	}
}
