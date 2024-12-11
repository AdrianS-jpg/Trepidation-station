using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitbutton : MonoBehaviour
{
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
