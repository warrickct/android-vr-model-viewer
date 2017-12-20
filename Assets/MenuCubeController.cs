using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCubeController : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.root.position = new Vector3(player.position.x, player.position.y, player.position.z + 2f);
	}
}
