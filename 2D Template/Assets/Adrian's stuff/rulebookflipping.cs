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
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        transform = GetComponent<Transform>();
        coll = GetComponent<BoxCollider2D>();
        rulebook = GameObject.Find("Rulebook");
        spriteholder = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>();
        Debug.Log(rulebook.GetComponent<Transform>().position.x);
        Debug.Log(rulebook.GetComponent<Transform>().localPosition.x);
        Debug.Log(rulebook.GetComponent<Transform>().TransformPoint(new Vector3(rulebook.GetComponent<Transform>().localPosition.x - 1, rulebook.GetComponent<Transform>().localPosition.y, rulebook.GetComponent<Transform>().localPosition.z)));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rulebook.GetComponent<SpriteRenderer>().sprite != spriteholder.rulebookCover)
        {
            if (active == false)
            {
                global();
                renderer.enabled = true;
                coll.enabled = true;
            }
            else
            {
                renderer.enabled = false;
                coll.enabled = false;
            }
        }
        else
        {
            renderer.enabled = false;
            coll.enabled = false;
        }
    }

    public void OnMouseDown()
    {
        if (active == false){
            if (rulebook.GetComponent<rulebookMovement>().spriteCount == 3)
            {
                rulebook.GetComponent<rulebookMovement>().spriteCount = 0;
                rulebook.GetComponent<SpriteRenderer>().sprite = spriteholder.rulebookSpriteList[0];
                Debug.Log("s");
            }
            else
            {
                rulebook.GetComponent<rulebookMovement>().spriteCount++;
                rulebook.GetComponent<SpriteRenderer>().sprite = spriteholder.rulebookSpriteList[rulebook.GetComponent<rulebookMovement>().spriteCount];
                Debug.Log(rulebook.GetComponent<rulebookMovement>().spriteCount);
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
        transform.localPosition = new Vector3(rulebook.GetComponent<Transform>().localPosition.x - 100, rulebook.GetComponent<Transform>().localPosition.y, -2);
    }
}
