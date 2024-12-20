using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingFunction : MonoBehaviour
{
    public List<string> sprites = new List<string>(); 
    public List<string> pattern = new List<string>() {"err191Bigfoot", "asdf"};
    public List<Sprite> papers = new List<Sprite>();
    public bool active = false;
    public static List<string> checkobjects = new List<string>();
    public GameObject prefabtext;
    public Canvas Canvas;
    public int passportnumber;
    public int patternNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            if (sprites.Count == 2)
            {
                if (sprites[0] == (sprites[1] + "orr") || sprites[1] == (sprites[0] + "orr"))
                {
                    GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if (sprites[0] == (sprites[1] + "err") || sprites[1] == (sprites[0] + "err"))
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                }
                else 
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    //drop();
                }
                sprites[0] = sprites[1];
                sprites.RemoveAt(1);
            }
        } else
        {
            sprites.Clear();
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void drop()
    {
        // get this to function correctly, it's not hooked up to anything. maybe make temp button for it?
        // this IS supposed to run when you call a new person so idk
        // maybe run this with turning the sprite on and the collider
        if (pattern[0].Substring(0 , 3) == "err")
        {
            CheckButton.corrects[Convert.ToInt32(pattern[0].Substring(2, 2))] = CheckButton.corrects[Convert.ToInt32(pattern[0].Substring(2, 2))].Remove(CheckButton.corrects[Convert.ToInt32(pattern[0].Substring(2, 2))].Length - 3,3) + "err";
        }
        Debug.Log(CheckButton.corrects[Convert.ToInt32(pattern[0].Substring(2, 2))]);
        if (GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite == GameObject.Find("Passport").GetComponent<WhenClicked>().sprite)
        {
            GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().passportSpriteList[(passportnumber * 2)];
        } else
        {
            GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().passportSpriteList[(passportnumber * 2) + 1];
        }
        
        GameObject.Find("Passport").GetComponent<WhenClicked>().sprite = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().passportSpriteList[passportnumber * 2];
        GameObject.Find("Passport").GetComponent<WhenClicked>().sprite2 = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().passportSpriteList[(passportnumber * 2) + 1];
    }
    public void whenPressed()
    {
        if (active == true)
        {
            active = false;
        } else
        {
            active = true;
            if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 1) {
                Debug.Log("asdg");
                spawnClone(-0.05f, 0f, 0f);
                spawnClone(-1.284f, 0.1f, 1f);
                spawnClone(-1.223f, 0.7882f, 2f);
                spawnClone(-0.4159f, 0.600f, 3f);
                spawnClone(0.449f, 0.736f, 4f);
            } 
            else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 2)
            {
                spawnClone(-1.1f, 0.6f, 5);
            }
            else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount >= 3 && GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount <= 7)
            {
                spawnClone(-1.5f, 0.3f, 6);
                spawnClone(-1f, -0.35f, 7);
                spawnClone(-1f, -0.7f, 8);
                spawnClone(-1f, -1.0f, 9);
            }
            else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 8)
            {
                spawnClone(-1, 0.15f, 10);
                spawnClone(-1, -0.5f, 11);
            }

            if (GameObject.Find("Passport").GetComponent<WhenClicked>().ifClickedOn == true)
            {
                //if (passportnumber == 0 || passportnumber == 3)
                //{
                    spawnClone(-1f, -1.1f, 12);
                    spawnClone(0.9f, -0.25f, 13);
                    spawnClone(0.9f, -0.70f, 14);
                    spawnClone(0.9f, -1.05f, 15);
                    spawnClone(0.9f, -1.40f, 16);
                //}
                //else 
                //// finish this
                ////yo past adrian your stupid it's already done dummy
                ////idiot
                ////fool
                //{
                //    Debug.Log("askljfhasljkdfh");
                //    spawnClone(1f, -1f, 12);
                //    spawnClone(-0.9f, -0.25f, 13);
                //    spawnClone(-0.9f, -0.70f, 14);
                //    spawnClone(-0.9f, -1.07f, 15);
                //    spawnClone(-0.9f, -1.50f, 16);
                //}

            }
            if (GameObject.Find("ID").GetComponent<SpriteRenderer>().enabled == true)
            {
                spawnClone(-0.77f, 0.29f, 17);
                spawnClone(0.4f, 0.55f, 18);
                spawnClone(0.4f, 0.27f, 19);
                spawnClone(0.4f, 0.01f, 20);
                spawnClone(0.37f, -0.21f, 21);
                //set this up to the ID prefab
            }
        }
    }

    public void spawnClone(float x, float y, float z)
    {

        GameObject g = Instantiate(prefabtext, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        g.transform.parent = Canvas.transform;
    }
}
