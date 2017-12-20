using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//summary
//Controls the settings panel changes
public class SettingController : MonoBehaviour {

    [SerializeField] private OVRInputModule ovrInputModule;
    [SerializeField] private Text newTeleportDistanceText;

    private string newTeleportDistance;

    //summary
    //Changes teleportDistance value in OVRPhysicsRaycaster
    public void UpdateLaser()
    {
        ovrInputModule.teleportDistance = Int32.Parse(newTeleportDistance);
    }

    //summary
    //Appends to the value of the new teleport distance
    public void UpdateNewTeleportDistance(string s)
    {
        newTeleportDistance += s;
        UpdateTeleportText();
        Debug.Log("new teleport distance: " + newTeleportDistance);
    }

    //summary
    //clears the new teleport distance string value
    public void ClearNewTeleportDistance()
    {
        newTeleportDistance = "";
        UpdateTeleportText();
    }

    //summary
    //updates the UI text of the new teleport value
    void UpdateTeleportText()
    {
        newTeleportDistanceText.text = newTeleportDistance;
    }

}
