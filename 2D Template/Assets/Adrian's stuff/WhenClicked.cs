using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenClicked : MonoBehaviour
{
    public Transform transform;
    bool ifClickedOn = false, follow = false, click = false, clickCheck = false, redMode = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite, sprite2;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(Camera.main.pixelWidth);
        Debug.Log(Camera.main.pixelHeight);  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition.x);
        if (click == true)
        {
            clickTime += Time.deltaTime;
            clickCheck = false;
            GetComponent<BoxCollider2D>().offset = new Vector2(-0.1414819f, 0.1061118f);
            GetComponent<BoxCollider2D>().size = new Vector2(2.202598f, 2.627044f);
            changeSprite(sprite);
        }
        if (click == false)
        {
            if (clickCheck == false)
            {
                if (clickTime <= 0.15f && clickTime >= 0.000000001f)
                {
                    follow = false;
                    if (ifClickedOn == false)
                    {
                        ifClickedOn = true;
                        changeSprite(sprite2);
                        GetComponent<BoxCollider2D>().offset = new Vector2(-0.05305538f, 0.0884265f);
                        GetComponent<BoxCollider2D>().size = new Vector2(1.106111f, 0.8938886f);
                    }
                    else
                    {
                        ifClickedOn = false;
                        changeSprite(sprite);
                        GetComponent<BoxCollider2D>().offset = new Vector2(-0.1414819f, 0.1061118f);
                        GetComponent<BoxCollider2D>().size = new Vector2(2.202598f, 2.627044f);
                    }


                }
            }
            clickCheck = true;


        }
        if (follow == true)
        {
            if (transform.position.x <= 5 && transform.position.x >= -5)
            {
                transform.position = new Vector3((Input.mousePosition.x - (Screen.width / 2)) / 50, (Input.mousePosition.y - (Screen.height / 2)) / 50, -1);
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

    public void whenPressed()
    {
        if (redMode == false)
        {
            redMode = true;
        }
        else
        {
            redMode = false;
        }
    }
}
