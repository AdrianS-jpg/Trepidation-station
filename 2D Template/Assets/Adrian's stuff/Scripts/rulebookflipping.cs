using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulebookflipping : MonoBehaviour
{
    public bool active = false;
    private Renderer renderer;
    private Transform transform;
    private GameObject rulebook;
    private BoxCollider2D coll;
    private spriteHolder spriteholder;
    public static bool side = false;
    public bool flip = false;
    public bool first = false;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        transform = GetComponent<Transform>();
        coll = GetComponent<BoxCollider2D>();
        rulebook = GameObject.Find("Rulebook");
        spriteholder = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (rulebook.GetComponent<SpriteRenderer>().sprite != spriteholder.rulebookCover)
        {
            if (active == false && first == false)
            {
                global();
                renderer.enabled = true;
                coll.enabled = true;
                first = true;
            }
            else if (active == false){
                if (side == false)
                {
                    transform.localPosition = new Vector3(rulebook.GetComponent<Transform>().localPosition.x - 75, rulebook.GetComponent<Transform>().localPosition.y - 55, -3);
                    side = true;
                }
                else if (side == true)
                {
                    transform.localPosition = new Vector3(rulebook.GetComponent<Transform>().localPosition.x + 75, rulebook.GetComponent<Transform>().localPosition.y - 55, -3);
                    side = false;
                }
            }
            else if (active == true) {
                renderer.enabled = false;
                coll.enabled = false;
                first = false;
            }
        }
        else
        {
            renderer.enabled = false;
            coll.enabled = false;
            first = false;
        }
    }

    public void OnMouseDown()
    {
        if (active == false){

            if (rulebook.GetComponent<rulebookMovement>().spriteCount == spriteholder.rulebookSpriteList.Count - 2 && flip == true)
            {
                rulebook.GetComponent<rulebookMovement>().spriteCount = spriteholder.rulebookSpriteList.Count - 2;
                rulebook.GetComponent<SpriteRenderer>().sprite = spriteholder.rulebookSpriteList[spriteholder.rulebookSpriteList.Count - 2];
            }
            else if (rulebook.GetComponent<rulebookMovement>().spriteCount == 0 && flip == false)
            {
                rulebook.GetComponent<rulebookMovement>().spriteCount = 0;
                rulebook.GetComponent<SpriteRenderer>().sprite = spriteholder.rulebookSpriteList[0];
            }
            else
            {
                if (flip == false)
                {
                    rulebook.GetComponent<rulebookMovement>().spriteCount--;
                }
                else if (flip == true)
                {
                    rulebook.GetComponent<rulebookMovement>().spriteCount += 1;
                }
                rulebook.GetComponent<SpriteRenderer>().sprite = spriteholder.rulebookSpriteList[rulebook.GetComponent<rulebookMovement>().spriteCount];
            }
        }
    }

    public void whenPressed()
    {
        if (active == false){
            active = true;
        } else {
            active = false;
        }
    }
    public void global()
    {
        if (side == false)
        {
            transform.localPosition = new Vector3(rulebook.GetComponent<Transform>().localPosition.x - 75, rulebook.GetComponent<Transform>().localPosition.y - 55, -3);
            side = true;
            flip = false;
        } else if (side == true) 
        {
            transform.localPosition = new Vector3(rulebook.GetComponent<Transform>().localPosition.x + 75, rulebook.GetComponent<Transform>().localPosition.y - 55, -3);
            side = false;
            flip = true;
        }
        
        
    }
}
