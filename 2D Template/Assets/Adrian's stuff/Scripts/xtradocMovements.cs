using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class xtradocMovements : MonoBehaviour
{
    public Transform transform;
    public bool follow = false, click = false, clickCheck = false, redMode = false;
    private float clickTime = 0f;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    // hey wait a min ive seen this newfangled sht before
    void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 mousePosition = Input.mousePosition;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
    }

    // i swear this wasn't used when i got it
    void Update()
    {
        if (transform.localPosition.x <= -1 * (GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x / 2))
        {
            transform.localPosition = new Vector2(-1 * (GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x / 2), transform.localPosition.y);
        }
        if (transform.localPosition.x >= (GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x / 2))
        {
            transform.localPosition = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x / 2, transform.localPosition.y);
        }
        if (transform.localPosition.y <= -1 * (GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y / 2))
        {
            transform.localPosition = new Vector2(transform.localPosition.x, -1 * (GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y / 2));
        }
        if (transform.localPosition.y >= GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y / 2)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y / 2);
        }
        if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().redMode == true)
        {
            redMode = true;
        }
        else
        {
            redMode = false;
        }
        if (redMode == false)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            if (click == true)
            {
                clickTime += Time.deltaTime;
                clickCheck = false;
            }
            if (click == false)
            {
                clickCheck = true;
            }
            if (follow == true)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                transform.position = mousePosition;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue);
            }
            else
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
        Debug.Log("work");

    }
}


