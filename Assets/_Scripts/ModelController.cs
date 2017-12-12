using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {

    public void LoadModel(string modelName)
    {
        GameObject modelGameObject = Resources.Load("Models/obj/" + modelName + "/" + modelName) as GameObject;
        GameObject instancedModel = Instantiate(modelGameObject);

        //TODO: Make it spawn in a uniform position
        instancedModel.transform.localPosition = Vector3.zero;
        instancedModel.transform.localRotation = Quaternion.identity;

        //TODO: for testing collider interaction isn't because we're inside collider

        instancedModel.AddComponent<VRInteractable>();

        //Generate mesh collider from Mesh renderer.
        //TODO: Make child objects combine their meshes into one mesh.

        /*
		Mesh modelMesh = instancedModel.GetComponentInChildren<MeshFilter> ().mesh;
		MeshCollider modelMeshCollider = instancedModel.AddComponent<MeshCollider> ();
		modelMeshCollider.sharedMesh = modelMesh;
        */
    }

    public void ClearAllModels() {
		GameObject[] modelsList = GameObject.FindGameObjectsWithTag ("Model");
		foreach (GameObject model in modelsList) {
			Destroy (model);
		}
	}
}
