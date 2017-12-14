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
    private char currentAxis;

    [SerializeField] Text rotateText;

    VRInteractable currentObjectInteractable;

    public void SetInteractiveItem(GameObject gameObj, int tap){
		currentGameObj = gameObj;
		Debug.Log ("Now interacting with " + gameObj);

		//if same as lastobj then deactivate current and set last to null
		if (currentGameObj == lastGameObj) {
            if (tap != 1)
                return;
			DeactivateObject (currentGameObj);
			lastGameObj = null;
		} else {
			ActivateObject (currentGameObj);
			DeactivateObject (lastGameObj);
			lastGameObj = currentGameObj;
		}
        currentObjectInteractable = currentGameObj.GetComponent<VRInteractable>();
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        switch (currentAxis)
        {
            case 'x':
                rotateSlider.value = currentObjectInteractable.xRotVelocity;
                break;
            case 'y':
                rotateSlider.value = currentObjectInteractable.yRotVelocity;
                break;
            case 'z':
                rotateSlider.value = currentObjectInteractable.zRotVelocity;
                break;
        }
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

    public void ChangeAxis(string axis)
    {
        currentAxis = System.Convert.ToChar(axis);
        UpdateSlider();
        rotateText.text = "Rotating: " + currentAxis; 
        Debug.Log("using " + currentAxis + " axis");
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

	public void UpdateRotation(float newSpeed){
        currentObjectInteractable = currentGameObj.GetComponent<VRInteractable>();
        if (currentObjectInteractable == null)
        {
            Debug.Log("Debug: no object selected");
            return;
        }
        currentObjectInteractable.ChangeRotation(newSpeed, currentAxis);
    }
}
