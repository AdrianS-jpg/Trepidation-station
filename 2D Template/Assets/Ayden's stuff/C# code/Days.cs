using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Days : MonoBehaviour
{
    public float choices = 0;
    public string LevelName;

    public void days()
    {
        if (choices == 10)
        {
            SceneManager.LoadSceneAsync(LevelName);
        }
    }


}
