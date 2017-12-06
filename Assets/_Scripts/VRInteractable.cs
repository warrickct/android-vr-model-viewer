using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

	public static ManipulateController manipulateController;
	public float rotateSpeed = 10f;

	public void OnEnable(){
		manipulateController = GameObject.Find ("ManipulatePanel").GetComponent<ManipulateController> ();
	}

	public void Update(){
		transform.Rotate(rotateSpeed/2f * Time.deltaTime, rotateSpeed * Time.deltaTime, 0);
	}

	//passes this gameobj to the manipulatecontroller script in the manipulate panel 
	//to be referenced when rotated/scaled.
	public virtual void OnPointerClick(PointerEventData eventData){
		Debug.Log (this.gameObject.ToString() + "  was clicked");
		manipulateController.setInteractiveItem (this.gameObject);
	}
}
