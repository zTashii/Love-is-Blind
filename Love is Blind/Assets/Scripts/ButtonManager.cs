using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour {

    public int level1 = 1;

    public void StartAgain(int levelIndex)
    {
        SceneManager.LoadSceneAsync(levelIndex);
    }


}
