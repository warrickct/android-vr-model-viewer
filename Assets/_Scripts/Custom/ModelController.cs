using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour {

	List<string> modelList = new List<string>();

    public void LoadModel(string modelName)
    {
        GameObject modelGameObject = Resources.Load("Models/obj/" + modelName + "/" + modelName) as GameObject;
        GameObject instancedModel = Instantiate(modelGameObject);
        //TODO: Make it spawn in a uniform position
        instancedModel.transform.localPosition = Vector3.zero;
        instancedModel.transform.localRotation = Quaternion.identity;
        instancedModel.AddComponent<VRInteractable>();
    }

    public void ClearAllModels() {
		GameObject[] modelsList = GameObject.FindGameObjectsWithTag ("Model");
		foreach (GameObject model in modelsList) {
			Destroy (model);
		}
	}

	public void AddToBatch(string modelName){
		modelList.Add (modelName);
	}

	public void InstantiateBatch(){
		foreach (string modelName in modelList) {
			LoadModel (modelName);
		}
	}
}
