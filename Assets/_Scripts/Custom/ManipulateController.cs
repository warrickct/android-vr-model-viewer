using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManipulateController : MonoBehaviour {

    public Shader Outline;
    public Shader Standard;
    public Slider rotateSlider;
    public Transform head;

    private GameObject currentGameObj;
    private GameObject lastGameObj = null;
    private char currentAxis;

    [SerializeField] Text rotateText;

    VRInteractable currentObjectInteractable;
    private GameObject teleportItem;
    private float teleportDistance;
    

    private void Start()
    {
        teleportDistance = 5f;
    }

    private void Update()
    {
        
    }

    public void SetInteractiveItem(GameObject gameObj, int tap){
		currentGameObj = gameObj;
        
        //ADDED: if same as lastobj set current object null
		//if same as lastobj then deactivate current and set last to null
		if (currentGameObj == lastGameObj) {
            if (tap != 1)
                return;
			DeactivateObject (currentGameObj);
			lastGameObj = null;
            currentGameObj = null;
		} else {
			ActivateObject (currentGameObj);
			DeactivateObject (lastGameObj);
			lastGameObj = currentGameObj;
		}
        //ADDED: if there is a current object, then update the slider
        if (currentGameObj != null)
        {
            currentObjectInteractable = currentGameObj.GetComponent<VRInteractable>();
            UpdateSlider();
        }
        Debug.Log("Now interacting with " + currentGameObj);
    }

    //ADDED: send the currentGameObj to VRInteratable script
    public GameObject WhatISCurrentItem()
    {
        if (currentGameObj != null) return currentGameObj;

        return null;
    }

    //Single click
    public void SingleClick()
    {
        teleportItem = currentGameObj;
    }


    //Double click
    public void DoubleClick()
    {

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
