using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int currentLevelIndex;

    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Contains("Player"))
        {
            SceneManager.LoadSceneAsync(currentLevelIndex + 1);
        }
    }

}
