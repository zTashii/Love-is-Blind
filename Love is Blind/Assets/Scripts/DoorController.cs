using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public PlayerController player;
    public GameObject currentDoor;
    public GameObject affectedDoor;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        currentDoor.SetActive(true);

    }
   

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            if (Input.GetButton("Use"))
            {
                currentDoor.SetActive(false);
                if (affectedDoor)
                {
                    affectedDoor.SetActive(true);
                }
            }

        }
    }
}
