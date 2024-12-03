using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public bool active = false;
    public Transform transform;
    public SpriteRenderer spriteRenderer;
    public Sprite sprit;
    public GameObject obj;
    public Camera camera;
    public bool runsTimes = false;
    public static List<float> placements = new List<float>() {0.7f,-0.7f,-1f,-2f};
    public static int placementnumberInList = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        camera = Camera.main;
        //obj = GameObject.Find("Rulebook");
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) 
        {
            if (GameObject.Find("Circle").GetComponent<settingFunction>().pattern[0] == "correct") { 

            }
            if (obj.GetComponent<SpriteRenderer>().sprite == sprit) {
                placeEverything();   
            }
            
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            runsTimes = false;
            placementnumberInList = 0;
        }
        Debug.Log(camera.WorldToScreenPoint(transform.position));

    }

    void OnMouseDown()
    {
        if (active == true)
        {
            GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add(GetComponent<SpriteRenderer>().sprite);
        }
    }
    public void whenPressed()
    {
        if (active == true){
            active = false;
        } else
        {
            active = true;
        }
    }
    public void placeEverything()
    {
        if (runsTimes == false)
        {
            GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            transform.position = new Vector3(obj.GetComponent<Transform>().transform.position.x + placements[placementnumberInList], obj.GetComponent<Transform>().transform.position.y + placements[placementnumberInList + 1], obj.GetComponent<Transform>().transform.position.z);
            runsTimes = true;
            placementnumberInList += 2;
        }
    }
}
