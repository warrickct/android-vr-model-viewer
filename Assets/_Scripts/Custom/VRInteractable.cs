using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    //TODO: panel ref wont be set if no obj with VRInteractable when scene starts.
	public static ManipulateController manipulateController;
    public float xRotVelocity=5;
    public float yRotVelocity=5;
    public float zRotVelocity=5;

    int tap;
    float startTime;
    float endTime;

    Collider modelCollider;

    public void Start(){
		this.gameObject.tag = "Model";
        CreateMeshFilter();

        //trying to find mesh center.
        modelCollider = this.gameObject.GetComponent<Collider>();
    }

    public void OnEnable(){
        if (manipulateController == null)
        {
            manipulateController = GameObject.Find("ManipulatePanel").GetComponent<ManipulateController>();
        }
    }

	public void Update(){
		transform.Rotate(xRotVelocity * Time.deltaTime, yRotVelocity * Time.deltaTime, zRotVelocity * Time.deltaTime);
	}

    
    public void OnPointerDown(PointerEventData eventData)
    {
        startTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endTime = Time.time;
        if ((endTime - startTime) > 0.5f)
        {
            manipulateController.SetInteractiveItem(this.gameObject);
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

    //Summary combined the child meshes then generates collider on parent. 
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
            modelMeshCollider.isTrigger = true;
		}
    }
}
