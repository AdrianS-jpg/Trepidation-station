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
    public GameObject passport;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        passport = GameObject.Find("Passport");
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true) 
        {
            if (passport.GetComponent<SpriteRenderer>().sprite == sprit) {
                GetComponent<Renderer>().enabled = true;
                transform.position = new Vector3(passport.GetComponent<Transform>().transform.position.x, passport.GetComponent<Transform>().transform.position.y, passport.GetComponent<Transform>().transform.position.z);
            }
            
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
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
