    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    GameObject[] menuPanelList;

	// Use this for initialization
	void Start () {
        menuPanelList = GameObject.FindGameObjectsWithTag("MenuPanel");
        foreach(GameObject menuPanel in menuPanelList)
        {
            menuPanel.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayMenu(GameObject menuToDisplay)
    {
        foreach (GameObject menuPanel in menuPanelList)
        {
            if (menuPanel == menuToDisplay)
            {
                menuPanel.SetActive(true);
            }
            else
            {
                menuPanel.SetActive(false);
            }
        }
    }


    //because display menu doesn't allow null value.
    public void CloseMenus()
    {
        foreach (GameObject menuPanel in menuPanelList)
        {
            menuPanel.SetActive(false);
        }
    }
}
