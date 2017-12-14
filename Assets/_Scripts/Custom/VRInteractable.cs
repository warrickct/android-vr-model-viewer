using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

    //TODO: panel ref wont be set if no obj with VRInteractable when scene starts.
	public static ManipulateController manipulateController;
    public float xRotVelocity=5;
    public float yRotVelocity=5;
    public float zRotVelocity=5;
    public Transform head;

    private GameObject teleportItem;

    int tap;
    private float teleportDistance = 5f;

    public void Start(){
		this.gameObject.tag = "Model";
        CreateMeshFilter();
	}

    public void OnEnable(){
        if (manipulateController == null)
        {
            manipulateController = GameObject.Find("ManipulatePanel").GetComponent<ManipulateController>();
        }

        if (head == null)
        {
            head = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();
        }
    }

	public void Update(){
		transform.Rotate(xRotVelocity * Time.deltaTime, yRotVelocity * Time.deltaTime, zRotVelocity * Time.deltaTime);

        if (OVRInput.GetDown(OVRInput.Button.DpadRight) && teleportDistance < 20f)
        {
            teleportDistance += .5f;
        }
        else if (OVRInput.GetDown(OVRInput.Button.DpadLeft) && teleportDistance > .5f)
        {
            teleportDistance -= .5f;
        }

        //if there is one click object to teleport
        if (teleportItem != null)
        {
            teleportItem.transform.position = head.position + teleportDistance * head.forward;
        }
    }

    

	//passes this gameobj to manipulate controller.
	public virtual void OnPointerClick(PointerEventData eventData){
        tap = eventData.clickCount;
        manipulateController.SetInteractiveItem(this.gameObject, tap);
        //ADDED: get teleportItem from ManipulateController.cs
        teleportItem = manipulateController.WhatISCurrentItem();
        Debug.Log("Current item: " +teleportItem);

        if (tap == 1)
        {
            Debug.Log("Single Click!");
            manipulateController.SingleClick();
            //manipulateController.SetInteractiveItem(this.gameObject);
        }
        else if (tap == 2)
        {
            //Destroy(this.gameObject);
        }
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

    public void CreateMeshFilter()
    {
        if (transform.GetComponent<Collider>() != null)
        {
            return;
        }
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }
        transform.gameObject.AddComponent<MeshFilter>();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		Mesh combinedMesh = transform.GetComponent<MeshFilter> ().mesh;
        transform.gameObject.SetActive(true);
        MeshCollider modelMeshCollider = transform.gameObject.AddComponent<MeshCollider>();
		if (combinedMesh.triangles.Length < 255) {
			modelMeshCollider.convex = true;
		}
    }
}
