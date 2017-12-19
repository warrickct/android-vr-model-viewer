using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleportable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    static GameObject player;
    int tap;

    float startTime;
    float endTime;

    public static OVRPhysicsRaycaster physicsCaster;

    //sets reference to player object.
    private void Awake()
    {
        player = GameObject.Find("Player");
        physicsCaster = GameObject.Find("Player").GetComponentInChildren<OVRPhysicsRaycaster>();
    }

   public virtual void OnPointerDown(PointerEventData eventData)
    {
        startTime = Time.time;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        endTime = Time.time;
        if ((endTime - startTime) < .5f)
        {
            Debug.Log("Short click - Teleporting");
            player.transform.position = eventData.pointerPressRaycast.worldPosition;
        }
    }
}
