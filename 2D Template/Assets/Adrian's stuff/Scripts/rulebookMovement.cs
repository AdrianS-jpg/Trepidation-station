using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                //spriteCount = 0;
                GetComponent<BoxCollider2D>().size = new Vector2(3.235898f, 2f);
            }
            else if (click == false)
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
                            spriteCount = spriteholder.rulebookSpriteList.Count - 1;
                            changeSprite(spriteholder.rulebookSpriteList[spriteCount]);
                            GetComponent<BoxCollider2D>().size = new Vector2(0.9f, 1.5f);
                        }
                        else
                        {
                            ifClickedOn = false;
                            clicked = false;
                            spriteCount = 0;
                            changeSprite(spriteholder.rulebookSpriteList[spriteCount]);
                            GetComponent<BoxCollider2D>().size = new Vector2(3.235898f, 2f);
                        }
                    }
                }
                clickCheck = true;
            }
            if (follow == true)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = -1;
                transform.position = mousePosition;
                transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue);
                
            } else
            {
                
                
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
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue);
            GameObject.Find("Circle").GetComponent<settingFunction>().zvalue--;
            GameObject.Find("Square").GetComponent<Transform>().localPosition = new Vector3(GameObject.Find("Square").GetComponent<Transform>().localPosition.x, GameObject.Find("Square").GetComponent<Transform>().localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue - 1);
            GameObject.Find("Button").GetComponent<Transform>().localPosition = new Vector3(GameObject.Find("Button").GetComponent<Transform>().localPosition.x, GameObject.Find("Button").GetComponent<Transform>().localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue - 20);
            GameObject.Find("Circle").GetComponent<Transform>().localPosition = new Vector3(GameObject.Find("Circle").GetComponent<Transform>().localPosition.x, GameObject.Find("Circle").GetComponent<Transform>().localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue - 2);
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
