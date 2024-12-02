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
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //obj = GameObject.Find("Passport");
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) 
        {
            if (GameObject.Find("Circle").GetComponent<settingFunction>().pattern[0] == "correct") { 

            }
            if (obj.GetComponent<SpriteRenderer>().sprite == sprit) {
                GetComponent<Renderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                transform.position = new Vector3(obj.GetComponent<Transform>().transform.position.x, obj.GetComponent<Transform>().transform.position.y, obj.GetComponent<Transform>().transform.position.z);
            }
            
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    private void OnMouseDown()
    {
        if (active == true)
        {
            GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add(GetComponent<SpriteRenderer>().sprite);
            //Debug.Log(GameObject.Find("SpriteHolder").GetComponent<settingFunction>().sprites.Capacity);
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
}
