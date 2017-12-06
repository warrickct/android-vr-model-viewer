using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour {

	[SerializeField] private Material[] skyboxList;

	public void ChangeSkybox(float sliderValue){
		int index = (int)sliderValue;
		RenderSettings.skybox = skyboxList [index];
	}
}
