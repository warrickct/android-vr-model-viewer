using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour {

    public float playerSpeed;
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");

        if (y > .1 && transform.position.y < 10000)
        {
            transform.position += Vector3.up * playerSpeed;
        }
        else if (y < -.1 && transform.position.y > -10)
        {
            transform.position -= Vector3.up * playerSpeed;
        }
        if (x > .1 && transform.position.x < 10000)
        {
            transform.position += Vector3.right * playerSpeed;
        }
        else if (x < -.1 && transform.position.x > -10)
        {
            transform.position += Vector3.left * playerSpeed;
        }
    }
}
