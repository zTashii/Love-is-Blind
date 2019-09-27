using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPosition;
    private Vector3 lightPosition;
    public float moveSpeed;

    private bool isPanComplete = false;
    private bool isFlashComplete = false;
    PlayerController player;
    public Light newLight;
  
    private void Start()
    {
        isPanComplete = true;
        player = followTarget.GetComponent<PlayerController>();

        
        //PanLevel();
    }


    private void Update()
    {
        //PanLevel();
        Flash();
        if (isPanComplete || isFlashComplete)
        {
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y + 1, followTarget.transform.position.z - 9);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            newLight.transform.position = Vector3.Lerp(newLight.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

    }

    public void Flash()
    {
        if (player.flashing)
        {
            isFlashComplete = false;
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y + 3, followTarget.transform.position.z - 27);
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            lightPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y + 3, followTarget.transform.position.y + 5);
            newLight.intensity = 30;
            newLight.transform.position = Vector3.Lerp(newLight.transform.position, lightPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            isFlashComplete = true;
            newLight.intensity = 0;
        }
    }

}
