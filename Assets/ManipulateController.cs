using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateController : MonoBehaviour {

	GameObject currentGameObj;

	public void setInteractiveItem(GameObject gameObj){
		currentGameObj = gameObj;
		Debug.Log ("Now interacting with " + gameObj);
	}

	public void ScaleUp (int newScale)
	{
		float newScaleValue = currentGameObj.transform.localScale.x * newScale;
		currentGameObj.transform.localScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
	}

	public void ScaleDown (int newScale)
	{
		float newScaleValue = currentGameObj.transform.localScale.x / newScale;
		currentGameObj.transform.localScale = new Vector3(newScaleValue, newScaleValue, newScaleValue);
	}

	public void UpdateSpeed(float newSpeed){
		VRInteractable currentObjectInteractable = currentGameObj.GetComponent<VRInteractable> ();
		currentObjectInteractable.rotateSpeed = newSpeed;
	}
}
