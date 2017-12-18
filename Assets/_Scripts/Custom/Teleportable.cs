using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleportable : MonoBehaviour, IPointerClickHandler {

    static GameObject player;
    int tap;

    public static OVRPhysicsRaycaster physicsCaster;

    //sets reference to player object.
    private void Awake()
    {
        player = GameObject.Find("Player");
        physicsCaster = GameObject.Find("Player").GetComponentInChildren<OVRPhysicsRaycaster>();
    }


    //TODO: Make raycast appear without having to look at an object.
    public virtual void OnPointerClick(PointerEventData eventData)
    {
		tap = eventData.clickCount;
        if (tap == 2)
        {
            Debug.Log("teleport function call");
            if (eventData != null)
                player.transform.position = eventData.pointerPressRaycast.worldPosition;
            else
                player.transform.position += Vector3.forward * 10f;
        }
    }
}
