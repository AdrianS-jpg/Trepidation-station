using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_game : MonoBehaviour
{
    public string LevelName;

    public void LoadLevel()
    {
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(LevelName);
    }
    public void LoadLevelAdditive()
    {
        StartCoroutine (MyCoroutine2());
    }
    IEnumerator MyCoroutine2()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(LevelName, LoadSceneMode.Additive);
    }
}
