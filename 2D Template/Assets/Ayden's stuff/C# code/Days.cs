using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Days : MonoBehaviour
{
    public float choices = 0;
    public string LevelName;

    public void Update()
    {
        if (choices == 10)
        {
            SceneManager.LoadScene(LevelName);
        }

    }
    public void next()
    {
        SceneManager.UnloadSceneAsync(LevelName);
    }


}
