using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collapsing Block")
        {
            //Destroy Block
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
    }

}
