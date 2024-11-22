using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenClicked : MonoBehaviour
{
    public Transform transform;
    public bool ifClickedOn = false, follow = false, click = false, clickCheck = false, redMode = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite, sprite2;
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 mousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (redMode == false) {
            if (click == true)
        {
            clickTime += Time.deltaTime;
            clickCheck = false;
            ifClickedOn = false;
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
                //if (transform.position.x <= 5 && transform.position.x >= -5)
                //{
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
                transform.position = mousePosition;
                //} else                                               
                //{
                //if (transform.position.x <= -5) 
                //{
                //    transform.position = new Vector3 (-5, transform.position.y, transform.position.z);
                //} else
                //{
                //    transform.position = new Vector3(5, transform.position.y, transform.position.z);
                //}
                //    follow = false;
                //}
            }
            Debug.Log(ifClickedOn);
        } else
        {

        }
    }
    void OnMouseDown()
    {
        if (redMode == false)
        {
            follow = true;
            clickTime = 0f;
            click = true;
        }
    }
    void OnMouseUp()
    {
        if (redMode == false) 
        {
        click = false;
        follow = false;
        }
        
        
    }

    void changeSprite(Sprite s)
    {
            spriteRenderer.sprite = s;
    }

    public void whenPressed()
    {
        if (redMode == false)
        {
            if (ifClickedOn == true)
            {
                changeSprite(sprite);
            } 
            else
            {
                changeSprite(sprite);
            }
            redMode = true;
        }
        else
        {
            redMode = false;
            //if (spriteRenderer.sprite == sprite3)
            //{
            //    changeSprite(sprite2);
            //}
        }
    }
}
