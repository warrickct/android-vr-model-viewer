using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleportable : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private GameObject player;

    int tap;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
		tap = eventData.clickCount;
        if (tap == 2)
        {
            //transport player to click position.
            Debug.Log("teleport function call");

            player.transform.position = eventData.pointerPressRaycast.worldPosition;
        }
    }
}
