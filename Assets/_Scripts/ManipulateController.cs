using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManipulateController : MonoBehaviour {

    GameObject currentGameObj;
	GameObject lastGameObj = null;
    public Shader Outline;
    public Shader Standard;
    public Slider rotateSlider;

    private void Start()
    {   
    }

    public void setInteractiveItem(GameObject gameObj){
		currentGameObj = gameObj;
		Debug.Log ("Now interacting with " + gameObj);

		//if same as lastobj then deactivate current and set last to null
		if (currentGameObj == lastGameObj) {
			DeactivateObject (currentGameObj);
			lastGameObj = null;
		} else {
			ActivateObject (currentGameObj);
			DeactivateObject (lastGameObj);
			lastGameObj = currentGameObj;
		}
		//if different
			//activate current
			//deactivate last
			//make last = current

        VRInteractable currentObjectInteractable = gameObj.GetComponent<VRInteractable>();
        rotateSlider.value = currentObjectInteractable.rotateSpeed;
    }

	private void ActivateObject(GameObject go){
		MeshRenderer[] currentMeshRenderList = go.GetComponentsInChildren<MeshRenderer>();
		Renderer[] currentRenderList = go.GetComponentsInChildren<Renderer>();
		foreach (MeshRenderer mr in currentMeshRenderList) {
			mr.material.shader = Outline;
		}
		foreach (Renderer r in currentRenderList) {
			r.material.shader = Outline;
		}
	}

	private void DeactivateObject(GameObject go){
		if (go == null) {
			return;
		}
		MeshRenderer[] currentMeshRenderList = go.GetComponentsInChildren<MeshRenderer>();
		Renderer[] currentRenderList = go.GetComponentsInChildren<Renderer>();
		foreach (MeshRenderer mr in currentMeshRenderList) {
			mr.material.shader = Standard;
		}
		foreach (Renderer r in currentRenderList) {
			r.material.shader = Standard;
		}
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
