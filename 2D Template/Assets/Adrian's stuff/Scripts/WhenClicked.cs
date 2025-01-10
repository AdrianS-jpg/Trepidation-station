using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenClicked : MonoBehaviour
{
    public Transform transform;
    public bool ifClickedOn = false, follow = false, click = false, clickCheck = false, redMode = false, clicked = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite, sprite2;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        //
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 mousePosition = Input.mousePosition;
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().redMode == true)
        {
            redMode = true;
        } else { 
            redMode = false;
        }
        if (redMode == false) {
            GetComponent<BoxCollider2D>().enabled = true;
            if (click == true)
            {
                clickTime += Time.deltaTime;
                clickCheck = false;
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.1414819f, 0.1061118f);
                GetComponent<BoxCollider2D>().size = new Vector2(2.202598f, 2.627044f);
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
                            changeSprite(sprite2);
                            GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                            GetComponent<BoxCollider2D>().size = new Vector2(2f, 2f);
                        }
                        else
                        {
                            ifClickedOn = false;
                            clicked = false;
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
                mousePosition.z = 0;
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
            else
            {
               
            }
        } else
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
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue);
            GameObject.Find("Circle").GetComponent<settingFunction>().zvalue--;
        }
    }

    void changeSprite(Sprite s)
    {
        spriteRenderer.sprite = s;
    }

}
