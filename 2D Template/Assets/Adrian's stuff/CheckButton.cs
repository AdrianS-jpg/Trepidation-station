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
    public string sprite = "sprite";
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
            if (GameObject.Find("SpriteHolder").GetComponent<settingFunction>().pattern[0] == "f") { 

            }
            if (obj.GetComponent<SpriteRenderer>().sprite == sprit) {
                GetComponent<Renderer>().enabled = true;
                transform.position = new Vector3(obj.GetComponent<Transform>().transform.position.x, obj.GetComponent<Transform>().transform.position.y, obj.GetComponent<Transform>().transform.position.z);
            }
            
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }

    }

    private void OnMouseDown()
    {
        if (active == true)
        {
            GameObject.Find("SpriteHolder").GetComponent<settingFunction>().sprites.Add(sprit);
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
