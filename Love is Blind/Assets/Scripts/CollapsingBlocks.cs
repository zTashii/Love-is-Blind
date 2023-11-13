using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBlocks : MonoBehaviour {

    Rigidbody cubeRigidBody;

    private void Start()
    {
        cubeRigidBody = GetComponent<Rigidbody>();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            cubeRigidBody.useGravity = true;
            
        }
    }


}
