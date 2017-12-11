using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

	public static ManipulateController manipulateController;

    public float xRotVelocity=5;
    public float yRotVelocity=5;
    public float zRotVelocity=5;

    public void Start(){
		this.gameObject.tag = "Model";
	}

    public void OnEnable(){
        //TODO:gives null reference error. If there's no interactable in the scene this will cause problems when loading a model
        //needs to be an obj with a vr interactable at the start or the ref to manipulate panel will never be created.
        //Possible solution: Make a emptygame obj with the interactable script that setactive false after references set up like the menu.
        if (manipulateController == null)
        {
            manipulateController = GameObject.Find("ManipulatePanel").GetComponent<ManipulateController>();
        }
    }

	public void Update(){
		transform.Rotate(xRotVelocity * Time.deltaTime, yRotVelocity * Time.deltaTime, zRotVelocity * Time.deltaTime);
	}

	//passes this gameobj ref to manipulate controller.
	public virtual void OnPointerClick(PointerEventData eventData){
		manipulateController.SetInteractiveItem (this.gameObject);
	}

    public void ChangeRotation(float newSpeed, char axis)
    {
        switch (axis)
        {
            case 'x':
                xRotVelocity = newSpeed;
                break;
            case 'y':
                yRotVelocity = newSpeed;
                break;
            case 'z':
                zRotVelocity = newSpeed;
                break;
            default:
                xRotVelocity = newSpeed;
                Debug.Log("no axis input. Defaulting to x axis");
                break;
        }
    }
}
