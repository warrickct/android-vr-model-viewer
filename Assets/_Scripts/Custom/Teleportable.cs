using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleportable : MonoBehaviour, IPointerClickHandler {

    static GameObject player;
    int tap;

    //sets reference to player object.
    private void Awake()
    {
        player = GameObject.Find("Player");
    }


    //TODO: Make raycast appear without having to look at an object.
    public virtual void OnPointerClick(PointerEventData eventData)
    {
		tap = eventData.clickCount;
        if (tap == 2)
        {
            Debug.Log("teleport function call");
            player.transform.position = eventData.pointerPressRaycast.worldPosition;
        }
    }
}
