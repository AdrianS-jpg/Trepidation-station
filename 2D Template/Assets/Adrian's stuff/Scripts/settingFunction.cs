using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class settingFunction : MonoBehaviour
{
    
    public List<string> sprites = new List<string>();
    [System.NonSerialized]
    public List<string> pattern = new List<string>() {
        "err14000100", //bigfoot
        "orr00401020", //frank    Hi, It's 1/9/2025 Adrian here with a quick explanation of how to Navigate this weird and wonderful set of, I'm sure, confusing mash of letters and numbers!
        "orr00002220", //blink    Once you understand it though, you can never forget it!
        "err15303020", //phillip  Lets use this --> "err1520401" as an example!
        "orr00304000", //yanagi   (err) this is to check if the passport is correct or not. orr is correct, err is incorrect (error).
        "err12005310", //david    (15) this is the hitbox/invisible text that will be changed to make sure the checking works. if you are not adrian/someone who understands this code, dont worry about this.
        "orr00006401", //fiona    (2) this is the number that connects to a list of passport covers. I need to know which cover to use for each character, so that's what this is for.       
        "orr00207020", //ichigo   (04) this is the placement of the passport in the spriteholder (see spriteholder passportSpriteList). This is mainly for just in case something breaks and i have to do some debugging .       
        "orr00108000", //mavis    (0) this is the variable that determines whether i need another paper or not. If it's 0, it'll have a basic ticket. otherwise, there's another list where it corresponds to. Most likely this is going to change in the future if we add more documents.
        "orr00109020", //whiskers (1) this is the location of the correct/incorrect location on the handbook. if it's 0, then it's the first location. if it's 1, it's the 2nd, and 2 means it's the 3rd.
        "orr00410020", //kumiko   That's all, Folks! your comprehensive guide to Adrian's weird, confusing, strange set of characters!
        "orr00311000", //shigure  
        "orr00412000", //spindler
        };
    public List<Sprite> papers = new List<Sprite>();
    public bool active = false;
    public static List<string> checkobjects = new List<string>();
    public GameObject prefabtext;
    public Canvas Canvas;
    public int passportnumber;
    public int patternNum;
    public bool end = false;
    public GameObject spriteHolder;
    public int splus = 0;
    public int zvalue = 0;
    public Sprite blankButton, redButton, yellowbutton, greenbutton;
    // Start is called before the first frame update
    void Start()
    {
        patternNum = -1;
        spriteHolder = GameObject.Find("SpriteHolder");
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
                if (sprites[0].Contains("orr") || sprites[1].Contains("orr"))
                {
                    if (sprites[0] == (sprites[1] + "orr") || sprites[1] == (sprites[0] + "orr") || sprites[0] == sprites[1])
                    {
                        GetComponent<SpriteRenderer>().sprite = greenbutton;
                    }
                } else if (sprites[0].Contains("err") || sprites[1].Contains("err"))
                {
                    if (sprites[0] == (sprites[1] + "err") || sprites[1] == (sprites[0] + "err") || sprites[0] == sprites[1])
                    {
                        GetComponent<SpriteRenderer>().sprite = redButton;
                    }
                }
                else if (sprites[0] == sprites[1])
                {
                    GetComponent<SpriteRenderer>().sprite = greenbutton;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = yellowbutton;
                    //drop();
                }
                sprites[0] = sprites[1];
                sprites.RemoveAt(1);
            }
        } else
        {
            sprites.Clear();
            GetComponent<SpriteRenderer>().sprite = blankButton;
        }
    }

    public void drop()
    {
        zvalue = 0;
        adding();
        if (end == false) { 
            splus = 0;
            foreach (string s in CheckButton.corrects.ToList())
            {
                if (s.Contains("err"))
                {
                    CheckButton.corrects[splus] = CheckButton.corrects[splus].Remove(CheckButton.corrects[splus].Length - 3, 3) + "orr";
                }
                if (s == "cityorr" || s == "cityerr")
                {
                    CheckButton.corrects[splus] = "rulebook";
                }
                splus++;
            }
            passportnumber = Convert.ToInt32(pattern[patternNum].Substring(5, 1));
            Debug.Log(passportnumber);
            Debug.Log(pattern.Count);
            Debug.Log(patternNum);
            // get this to function correctly, it's not hooked up to anything. maybe make temp button for it?
            // this IS supposed to run when you call a new person so idk
            // maybe run this with turning the sprite on and the collider
            //
            //it works now (somewhat)
            //collider is NOT being turned on that sht is not happening
            if (pattern[patternNum].Substring(0, 3) == "err")
            {
                CheckButton.corrects[Convert.ToInt32(pattern[patternNum].Substring(3, 2))] = CheckButton.corrects[Convert.ToInt32(pattern[patternNum].Substring(3, 2))].Remove(CheckButton.corrects[Convert.ToInt32(pattern[patternNum].Substring(3, 2))].Length - 3, 3) + "err";
            } 
            if (Convert.ToInt32(pattern[patternNum].Substring(3, 2)) >= 15 && Convert.ToInt32(pattern[patternNum].Substring(3, 2)) <= 17)
                {
                    CheckButton.corrects[Convert.ToInt32(pattern[patternNum].Substring(3, 2))] = "city";
                }
            //else
            //{


            //}
            if (pattern[patternNum].Substring(8, 1) == "0")
            {
                GameObject.Find("ID").GetComponent<SpriteRenderer>().sprite = spriteHolder.GetComponent<spriteHolder>().IDSpriteList[0];

            }
            else
            {
                GameObject.Find("ID").GetComponent<SpriteRenderer>().sprite = spriteHolder.GetComponent<spriteHolder>().IDSpriteList[Convert.ToInt32(pattern[patternNum].Substring(8, 1))];
            }
            if (GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite == GameObject.Find("Passport").GetComponent<WhenClicked>().sprite)
            {
                GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite = spriteHolder.GetComponent<spriteHolder>().passportSpriteList[(passportnumber * 2)];
            }
            if (pattern[patternNum].Substring(10, 1) == "0") 
            {
                GameObject.Find("xtra documents").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("xtra documents").GetComponent<BoxCollider2D>().enabled = false;
            } else
            {
                GameObject.Find("xtra documents").GetComponent<SpriteRenderer>().sprite = spriteHolder.GetComponent<spriteHolder>().specialItemSpriteList[Convert.ToInt32(pattern[patternNum].Substring(10,1)) - 1];
                GameObject.Find("xtra documents").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("xtra documents").GetComponent<BoxCollider2D>().enabled = true;
            }


            GameObject.Find("Passport").GetComponent<WhenClicked>().sprite = spriteHolder.GetComponent<spriteHolder>().passportSpriteList[passportnumber * 2];
            GameObject.Find("Passport").GetComponent<WhenClicked>().sprite2 = spriteHolder.GetComponent<spriteHolder>().characterSpriteList[Convert.ToInt32(pattern[patternNum].Substring(6, 2))];
        }
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
                if (passportnumber == 4 || passportnumber == 2)
                {
                    spawnClone(1f, -1f, 12);
                    spawnClone(-0.9f, -0.25f, 13);
                    spawnClone(-0.9f, -0.70f, 14);
                    spawnClone(-0.9f, -1.07f, 15);
                    spawnClone(-0.9f, -1.50f, 16);
                }
                else
                // finish this

                //yo past adrian your stupid it's already done dummy
                //idiot
                //fool
                {
                    spawnClone(-1f, -1.1f, 12);
                    spawnClone(0.9f, -0.25f, 13);
                    spawnClone(0.9f, -0.70f, 14);
                    spawnClone(0.9f, -1.05f, 15);
                    spawnClone(0.9f, -1.40f, 16);
                }

            }
            if (GameObject.Find("ID").GetComponent<SpriteRenderer>().enabled == true)
            {
                spawnClone(-0.77f, 0.29f, 17);
                spawnClone(0.4f, 0.55f, 18);
                spawnClone(0.4f, 0.27f, 19);
                spawnClone(0.4f, 0.01f, 20);
                spawnClone(0.37f, -0.21f, 21);
                //set this up to the ID prefab

                //ok its done
                //I LIED FKER DO THIS SHT
                //set this do it wont spawn when it's on the ticket sprite

                //nah man imma do my own thing
                //jkjk ill do this over the weekend or smth im too lazy to do it now

                //yo sunday adrian do this pleas
            }
            if (GameObject.Find("xtra documents").GetComponent<SpriteRenderer>().enabled == true)
            {
                spawnClone(-0.1f, 0.2f, 22);
                spawnClone(0f ,0f, 23);
                spawnClone(0f, -0.6f, 24);
               
            }
        }
        //Debug.Log(CheckButton.corrects[8]);
    }

    public void spawnClone(float x, float y, float z)
    {

        GameObject g = Instantiate(prefabtext, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        g.transform.parent = Canvas.transform;
    }
    public void adding()
    {
        if (pattern.Count - 1 == patternNum)
        {
            end = true;
        } else
        {
            patternNum++;
        }
    }
}
