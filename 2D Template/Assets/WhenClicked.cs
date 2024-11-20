using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenClicked : MonoBehaviour
{
    private float beforeX = 0, beforeY = 0;
    public Transform transform;
    bool ifClickedOn = false, follow = false, click = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite, sprite2;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (click == true)
        {
            clickTime += Time.deltaTime;
            changeSprite(sprite);
        }
        if (click == false)
        {
            if (clickTime <= 0.1f)
            {
                follow = false;
                transform.position = new Vector3(0, 0, 1);
                ifClickedOn = true;
                changeSprite(sprite2);
            }

        }
        if (follow == true)
        {
            if (transform.position.x <= 5 && transform.position.x >= -5)
            {
                transform.position = new Vector3((Input.mousePosition.x - 480) / 50, (Input.mousePosition.y - 250) / 50, -1);
                Debug.Log(transform.position.x);
            } else
            {
                if (transform.position.x <= -5) 
                {
                    transform.position = new Vector3 (-5, transform.position.y, transform.position.z);
                } else
                {
                    transform.position = new Vector3(5, transform.position.y, transform.position.z);
                }
                follow = false;
                Debug.Log(follow);
            }
            

        }
    }
    void OnMouseDown()
    {
        follow = true;
        clickTime = 0f;
        click = true;
    }
    void OnMouseUp()
    {
        click = false;
        follow = false;

    }

    void changeSprite(Sprite s)
    {
            spriteRenderer.sprite = s;
    }
}
