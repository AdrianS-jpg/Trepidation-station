using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public string LevelName;
    // Start is called before the first frame update
    public static Sprite monster;
    public float speed;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = monster;

        float random = Random.Range(1, 360);
        float x = Mathf.Sin(random);
        float y = Mathf.Cos(random);

        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y)*speed;

    }
    public void OnMouseDown()
    {
        Debug.Log("Fire");
        SceneManager.UnloadSceneAsync(LevelName);
        FindObjectOfType<NPCmovement>().location = NPCmovement.Location.GUN;
        FindObjectOfType<NPCmovement>().denyer();
        
    }
}
