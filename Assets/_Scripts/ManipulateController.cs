using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManipulateController : MonoBehaviour {

    GameObject currentGameObj;
    GameObject lastGameObj;
    public Shader Outline;
    public Shader Standard;
    public Slider rotateSlider;

    private void Start()
    {   
    }

    public void setInteractiveItem(GameObject gameObj){
		currentGameObj = gameObj;
		Debug.Log ("Now interacting with " + gameObj);
        
        currentGameObj.GetComponent<MeshRenderer>().material.shader = Outline;

        //check whether if the current model is the same as the last model
        //cube.GetComponent<Renderer>().material.shader = Standard;
        if (currentGameObj != lastGameObj)
        {
            //Deactivate the last object if it's not the same
            DeactivateLastObject();
            lastGameObj = currentGameObj;
        }
        else
        {
            //Deactivate the current object if it's the same
            currentGameObj.GetComponent<MeshRenderer>().material.shader = Standard;
            lastGameObj = null;
            currentGameObj = null;
        }

        VRInteractable currentObjectInteractable = gameObj.GetComponent<VRInteractable>();
        rotateSlider.value = currentObjectInteractable.rotateSpeed;
    }

    private void DeactivateLastObject()
    {
        //if there was no last game object
        if (lastGameObj == null)
        {
            return;
        }
        //if there was a last game object
        lastGameObj.GetComponent<Renderer>().material.shader = Standard;
        lastGameObj = null;
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
        VRInteractable currentObjectInteractable = currentGameObj.GetComponent<VRInteractable>();
        currentObjectInteractable.rotateSpeed = newSpeed;
    }
}
