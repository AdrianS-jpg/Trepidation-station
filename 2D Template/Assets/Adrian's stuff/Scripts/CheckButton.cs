using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public bool active = false;
    public Transform transform;
    public Sprite sprit;
    public GameObject obj;
    public Camera camera;
    public bool runsTimes = false;
    public string whatThisIs;
    public static List<float> Size = new List<float>() {
        0.02025991f, 0.007444256f, //0
        0.01097764f, 0.005743125f,
        0.01305398f, 0.005743125f,
        0.008274899f, 0.002899706f,
        0.01515058f, 0.003617398f,
        0.02337617f, 0.008992958f,
        0.008211082f, 0.01036148f,
        0.0225562f, 0.003995122f,
        0.0225562f, 0.003995122f,
        0.0225562f, 0.003995122f,
        0.02340841f, 0.009243746f,
        0.01551636f, 0.009243746f,
        //11 ^ 
        //12 v
        0.01803832f, 0.01869354f,
        0.03211192f, 0.006273255f,
        0.03211192f, 0.005332447f,
        0.03211192f, 0.005332447f,
        0.03211192f, 0.005332447f, 
        //17 V
        0.01013526f, 0.009875286f,
        0.02158399f, 0.003514871f,
        0.02198755f, 0.003074671f,
        0.02198755f, 0.003835016f,
        0.02190684f, 0.004235197f,
        //21 ^
        //22 v
        0.02551817f, 0.003587304f,
        0.02700807f, 0.003067695f,
        0.02742732f, 0.004620694f,
        //24 ^
        //25 v
        0.02331869f, 0.004310818f,
        0.02332804f, 0.003392152f,
        0.02312684f, 0.003608044f,
        0.02312684f, 0.003105424f,
        0.02312684f, 0.002728462f,
        0.008934576f, 0.008382924f,

        };
    // list for sizes
    // this is nessesary i promise

    //yeah yeah there is no other possible way guys i promise 
    //past adrian casually saving my ass when he labeled the hitbox sizes
    public string nameOfPlace;
    //right this is fked uhh somehow gotta get this to work

    //well it works now sooooooooo
    public static List<string> corrects = new List<string>() {"rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "pictureorr", "nameorr", "birthorr", "city", "classorr", "picture", "name", "birth", "weight", "class", "name", "origin", "thing", "nameorr", "birthorr", "classorr", "weightorr", "originorr", "pictureorr"};
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        camera = Camera.main;
        placeEverything();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().redMode == true)
        {

            if (FindObjectOfType<settingFunction>().spritesgo.Count == 2)
            {
                Debug.Log("as");
                if (gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[0] && gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[1])
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("wrok");
                }
                else
                {
                    Debug.Log("not");
                }
            }

        }
        else
        {
            Destroy(gameObject);
            runsTimes = false;

        }

    }

    void OnMouseDown()
    {
        GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add(whatThisIs);
        GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo.Add(gameObject);
        GetComponent<SpriteRenderer>().enabled = true;
        //if (FindObjectOfType<settingFunction>().spritesgo.Count == 2)
        //{
            Debug.Log("as");
            if (gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[0] && gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[1])
            {
                GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("wrok");
            }
            else
            {
                Debug.Log("not");
            }
        //}
    }
    public void placeEverything()
    {
        if (runsTimes == false)
        { 

            if ((transform.position.z + 0.1f) >= 0 && transform.position.z <= 11)
            {
                Debug.Log("sl");
                nameOfPlace = "Rulebook";
                if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount) == ((Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(5, 1))) + 3))
                {
                    if (Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(3, 2)) >= 15 && Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(3, 2)) <= 17)
                    {
                        Debug.Log(Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Length));
                        corrects[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(9, 1)) + 7] = "cityerr";
                    }
                    else if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 9)
                    {
                        Debug.Log("aksjhdkjashdflashdkflasdf");
                        corrects[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(9, 1)) + 7] = "cityorr";

                    }

                }
            }
                else if ((transform.position.z + 0.1f) >= 12 && transform.position.z <= 16)
                {
                    nameOfPlace = "Passport";
                    Debug.Log("sl");
                }
                else if ((transform.position.z + 0.1f) >= 17 && transform.position.z <= 21)
                {
                    nameOfPlace = "ID";
                    Debug.Log("sm");
                }
                else if (((transform.position.z + 0.1f) >= 22 && transform.position.z <= 24))
                {
                    nameOfPlace = "xtra documents";
                }
                else if (((transform.position.z + 0.1f) >= 25 && transform.position.z <= 31))
                {
                    nameOfPlace = "Entry Card";
                }
                whatThisIs = corrects[(int)(transform.position.z + 0.1f)];
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<Transform>().localScale = new Vector2((Size[(int)(transform.position.z + 0.1f) * 2] * 3299.754f), (Size[(int)((transform.position.z + 0.1f) * 2) + 1] * 3327.64f));
                transform.position = new Vector3(GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.x + transform.position.x, GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.y + transform.position.y, -3);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, GameObject.Find("Circle").GetComponent<settingFunction>().zvalue - 3);
                runsTimes = true;

            }

        }
    
    public void sleep(){
        Debug.Log("sleep");
        if (FindObjectOfType<settingFunction>().spritesgo.Count == 2) { 
            Debug.Log("as");
            if (gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[0] && gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[1])
            {
                GetComponent<SpriteRenderer>().enabled = false;
                Debug.Log("wrok");
            } else {
                Debug.Log("not");
            }
        } else if (FindObjectOfType<settingFunction>().spritesgo.Count == 1){
            Debug.Log("asd");
            if (gameObject != GameObject.Find("Circle").GetComponent<settingFunction>().spritesgo[0]){
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
