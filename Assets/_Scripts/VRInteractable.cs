using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

	public ManipulateController manipulateController;
	public float rotateSpeed = 10f;

	public void OnEnable(){
		manipulateController = GameObject.Find ("ManipulatePanel").GetComponent<ManipulateController> ();
	}

	public void Update(){
		transform.Rotate(rotateSpeed/2f * Time.deltaTime, rotateSpeed * Time.deltaTime, 0);
	}

	public virtual void OnPointerClick(PointerEventData eventData){
		Debug.Log (this.gameObject.ToString() + "  was clicked");

		//passes this gameobj to the manipulatecontroller script in the manipulate panel 
		//to be referenced when rotated/scaled.
		manipulateController.setInteractiveItem (this.gameObject);
	}
}
