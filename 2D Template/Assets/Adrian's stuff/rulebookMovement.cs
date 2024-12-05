using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class rulebookMovement : MonoBehaviour
{
    public Transform transform;
    public bool ifClickedOn = false, follow = false, click = false, clickCheck = false, redMode = false, clicked = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite, sprite2, sprite3;
    public int spriteCount = 0;
    public spriteHolder spriteholder;

    // Start is called before the first frame update
    void Start()
    {
        //sprite2 = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().rulebookDefault;
        //sprite3 = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().rulebookBlank;
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 mousePosition = Input.mousePosition;
        spriteholder = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (redMode == false)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            if (click == true)
            {
                clickTime += Time.deltaTime;
                clickCheck = false;
                spriteCount = 1;
                GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 2f);
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
                            clicked = true;
                            spriteCount = 4;
                            changeSprite(spriteholder.rulebookSpriteList[spriteCount]);
                            GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 1.5f);
                        }
                        else
                        {
                            ifClickedOn = false;
                            clicked = false;
                            spriteCount = 0;
                            changeSprite(spriteholder.rulebookSpriteList[spriteCount]);
                            GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 2f);
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
                mousePosition.z = -1;
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
            } else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1);
            }
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
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
        if (redMode == true)
        {
            redMode = false;
        }
        else
        {
            redMode = true;
        }
    }
}
