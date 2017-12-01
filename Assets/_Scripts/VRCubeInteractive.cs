using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCubeInteractive : MonoBehaviour {

    public Renderer cube_renderer;
    public float speed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    public void PointerClick()
    {
        cube_renderer.material.color = Color.cyan;
    }

    public void UpdateSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void UpdateScale(float scaleSpeed)
    {
        transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime);
    }
}
