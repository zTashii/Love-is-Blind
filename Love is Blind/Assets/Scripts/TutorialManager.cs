using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    public GameObject uiText;
    float timer = 3;
    bool startTimer;

    private void Start()
    {
        startTimer = false;
    }

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            uiText.SetActive(false);
            startTimer = false;
            Destroy(gameObject);
            Destroy(uiText);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            startTimer = true;
            uiText.SetActive(true);
        }
    }



}
