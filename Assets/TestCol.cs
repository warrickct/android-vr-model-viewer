using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCol : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("hit");
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Model")
        {
            this.gameObject.transform.localScale += new Vector3(1f, 1f, 1f);
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void OnCollisionExit(Collision col)
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;

    }
}
