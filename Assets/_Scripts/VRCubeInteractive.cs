using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCubeInteractive : MonoBehaviour {

    public Renderer cube_renderer;
    public float speed = 10f;

    public bool isGrowing = true;
    public float scaleValue = 0;

	void Start () {
	}
	
	void Update () {
        transform.Rotate(0, speed * Time.deltaTime, 0);

        transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
    }

    public void PointerClick()
    {
        cube_renderer.material.color = Color.cyan;
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ScaleUp (int newScale)
    {
        //can't use *= operator on Vector3
        transform.localScale = new Vector3(transform.localScale.x * newScale, transform.localScale.y * newScale, transform.localScale.z * newScale);
    }

    public void ScaleDown (int newScale)
    {
        transform.localScale = new Vector3(transform.localScale.x / newScale, transform.localScale.y / newScale, transform.localScale.z / newScale);
    }
}
