using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

	public static ManipulateController manipulateController;
	public float rotateSpeed = 10f;

	public void Start(){
		this.gameObject.tag = "Model";
	}

	public void OnEnable(){
		//TODO:gives null reference error. If there's no interactable in the scene this will cause problems when loading a model
		//needs to be an obj with a vr interactable at the start or the ref to manipulate panel will never be created.
		//Possible solution: Make a emptygame obj with the interactable script that setactive false after references set up like the menu.
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
