using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour {

	//TODO: Can make skybox list be updated on start up or when new skybox added.
	[SerializeField] private Material[] skyboxList;

	//not necessary. Load a default skybox
	public void Awake(){
		RenderSettings.skybox = skyboxList [3];
	}

	public void ChangeSkybox(float sliderValue){
		int index = (int)sliderValue;
		RenderSettings.skybox = skyboxList [index];
	}
}
