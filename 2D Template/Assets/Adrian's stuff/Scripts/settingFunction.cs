using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingFunction : MonoBehaviour
{
    public List<string> sprites = new List<string>(); 
    public List<Sprite> pattern = new List<Sprite>();
    public List<Sprite> papers = new List<Sprite>();
    public bool active = false;
    public static List<string> checkobjects = new List<string>();
    public GameObject prefabtext;
    public Canvas Canvas;
    public int passportnumber;
    // Start is called before the first frame update
    void Start()
    {
        passportnumber = Random.Range(0, 5);
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
                if (sprites[0] == (sprites[1] + "corr") || sprites[1] == (sprites[0] + "corr"))
                {
                    GetComponent<SpriteRenderer>().color = Color.green;
                }
                else if (sprites[0] == (sprites[1] + "err") || sprites[1] == (sprites[0] + "err"))
                {
                    GetComponent <SpriteRenderer>().color = Color.red;
                }
                else 
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    drop();
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
        passportnumber = Random.Range(0, 5);
        Debug.Log(passportnumber);
        GameObject.Find("Passport").GetComponent<SpriteRenderer>().sprite = GameObject.Find("SpriteHolder").GetComponent<spriteHolder>().passportSpriteList[passportnumber * 2];
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
                spawnClone(0, 0, 12);
                spawnClone(0, 0, 13);
                spawnClone(0, 0, 14);
                spawnClone(0, 0, 15);
                spawnClone(0, 0, 16);
            }
        }
    }

    public void spawnClone(float x, float y, float z)
    {

        GameObject g = Instantiate(prefabtext, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        g.transform.parent = Canvas.transform;
    }
}
