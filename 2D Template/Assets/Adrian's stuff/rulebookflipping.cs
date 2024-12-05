using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulebookflipping : MonoBehaviour
{
    public bool active = false;
    private Renderer renderer;
    private Transform transform;
    private GameObject rulebook;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
        transform = GetComponent<Transform>();
        rulebook = GameObject.Find("Rulebook");
        Debug.Log(rulebook.GetComponent<Transform>().position.x);
        Debug.Log(rulebook.GetComponent<Transform>().localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true){
            transform.position = new Vector3(rulebook.GetComponent<Transform>().localPosition.x - 1f,rulebook.GetComponent<Transform>().position.y,rulebook.GetComponent<Transform>().position.z);
            renderer.enabled = true;
        }
        else {
            renderer.enabled = false;
        }
    }

    public void OnMouseDown()
    {
        if (active == true){

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
}
