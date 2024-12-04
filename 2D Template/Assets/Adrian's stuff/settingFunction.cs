using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingFunction : MonoBehaviour
{
    public List<float> sprites = new List<float>(); 
    public List<string> pattern = new List<string>();
    public bool active = false;
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
                if (sprites[0] == sprites[1])
                {
                    GetComponent<SpriteRenderer>().color = Color.green;
                }
                else 
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
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
        int nc = Random.Range(1, 6);
        if (nc < 6)
        {
            pattern.Add("correct");
        }
        else
        {
            pattern.Add("incorrect");
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
            if (GameObject.Find("Rulebook").GetComponent<SpriteRenderer>().sprite == GameObject.Find("Rulebook").GetComponent<rulebookMovement>().sprite2) {
                Instantiate(prefabtext, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
