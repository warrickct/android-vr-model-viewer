﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//test trying to add button at runtime
using UnityEngine.UI;

public class ModelController : MonoBehaviour {

    public void LoadModel()
    {
        GameObject modelGameObject = Resources.Load("Models/obj/cicada-pomponia/cicada-rigsters") as GameObject;
        GameObject instancedModel = Instantiate(modelGameObject);

        instancedModel.transform.localPosition = Vector3.zero;
        instancedModel.transform.localRotation = Quaternion.identity;

		Mesh modelMesh = instancedModel.GetComponent<Mesh>();
		MeshCollider modelMeshCollider = instancedModel.AddComponent<MeshCollider> ();
		modelMeshCollider.sharedMesh = modelMesh;

		instancedModel.AddComponent<VRInteractable> ();
    }

	void SetSelectedObject(GameObject go){
		Debug.Log (go + " is the selected game object");
	}
}
