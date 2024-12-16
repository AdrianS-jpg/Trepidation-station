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
    // Start is called before the first frame update
    void Start()
    {
        drop();
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
                if (sprites[0] == (sprites[1] + "sf") || sprites[1] == (sprites[0] + "sf"))
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
                //-5.320902 x 
                //-0.4612478 y
                //-4.405 x
                //0.139 y
                Instantiate(prefabtext, new Vector3(-0.05f, 0, 0), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(-1.284f, 0.1f, 1), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(-1.223f, 0.7882f, 2), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(-0.4159f, 0.600f, 3), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(0.449f, 0.736f, 4), Quaternion.identity);
            } else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 2)
            {
                Instantiate(prefabtext, new Vector3(0.8f, 0.5f, 5), Quaternion.identity);
            }
            else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount > 3 && GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount <= 7)
            {
                Instantiate(prefabtext, new Vector3(2, 0, 6), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(2, 0, 7), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(2, 0, 8), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(2, 0, 9), Quaternion.identity);
            }
            else if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 8)
            {
                Instantiate(prefabtext, new Vector3(3, 0, 10), Quaternion.identity);
                Instantiate(prefabtext, new Vector3(3, 0, 11), Quaternion.identity);
            }
        }
    }
}
