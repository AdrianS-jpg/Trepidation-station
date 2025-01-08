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
        0.02190684f, 0.004235197f}; 
    // list for sizes
    // this is nessesary i promise

    //yeah yeah there is no other possible way guys i promise 
    //past adrian casually saving my ass when he labeled the hitbox sizes
    public string nameOfPlace;
    //right this is fucked uhh somehow gotta get this to work
    public static List<string> corrects = new List<string>() {"rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "rulebook", "pictureorr", "nameorr", "birthorr", "cityorr", "classorr", "picture", "name", "birth", "weight", "class"};
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        camera = Camera.main;
        placeEverything();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Rulebook").GetComponent<rulebookMovement>().redMode == true) 
        {

            //if (GameObject.Find("Circle").GetComponent<settingFunction>().pattern[placementnumberInList / 2] == "correct") { 

//            }
            //if (obj.GetComponent<SpriteRenderer>().sprite == sprit)
            //{

            //}

        }
        else
        {
            Destroy(gameObject);
            runsTimes = false;
        }
        //Debug.Log(camera.WorldToScreenPoint(transform.position));
        //tf is THIS ^

    }

    void OnMouseDown()
    {
        GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add(whatThisIs);
    }
    public void placeEverything()
    {
        if (runsTimes == false)
        {
            //new idea: computer knows where to put boxes because of original vector in which it is spawned into, the (x, y, z) coordinate bc it changes immiedently. 
            //or just use the vector itself as the coordinates
            //i might be both stupid and smart at the same time chat
            //GetComponent<Renderer>().enabled = true;

            //not sure why this exists imma be fully honest but hey
            if ((transform.position.z + 0.1f) >= 0 && transform.position.z <= 11)
            {
                nameOfPlace = "Rulebook";
                Debug.Log((Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum - 1].Substring(5, 1))));
                if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount) == ((Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum - 1].Substring(5,1))) + 3))
                {
                    if (Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum - 1].Length) == 9)
                    {
                        corrects[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum - 1].Substring(8,1)) + 7] = "city";
                        Debug.Log(corrects[9]);
                        Debug.Log(corrects[15]);
                    }
                    
                }
                //if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 3))
                //{
                //    if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 8)
                //    {
                //        corrects[7] = "rulebookbannerfell";

                //    }
                //    else if ((transform.position.z + 0.1f) >= 8 && transform.position.z <= 9)
                //    {
                //        corrects[8] = "rulebookschichberg";
                //    }
                //    else
                //    {
                //        corrects[9] = "rulebookrivengrad";
                //    }
                //}
                //else if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 4))
                //{
                //    if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 8)
                //    {
                //        corrects[7] = "rulebookgreatvida";

                //    }
                //    else if ((transform.position.z + 0.1f) >= 8 && transform.position.z <= 9)
                //    {
                //        corrects[8] = "rulebooknewunity";
                //    }
                //    else
                //    {
                //        corrects[9] = "rulebookitchdotio";
                //    }
                //}
                //else if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 5))
                //{
                //    if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 8)
                //    {
                //        corrects[7] = "rulebookpatrigrad";

                //    }
                //    else if ((transform.position.z + 0.1f) >= 8 && transform.position.z <= 9)
                //    {
                //        corrects[8] = "rulebookkusolnov";
                //    }
                //    else
                //    {
                //        corrects[9] = "rulebookmirsalva";
                //    }
                //}
                //else if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 6))
                //{
                //    if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 8)
                //    {
                //        corrects[7] = "rulebooktoadtown";

                //    }
                //    else if ((transform.position.z + 0.1f) >= 8 && transform.position.z <= 9)
                //    {
                //        corrects[8] = "rulebookfrogville";
                //    }
                //    else
                //    {
                //        corrects[9] = "rulebookeastfrog";
                //    }
                //}
                //else if ((GameObject.Find("Rulebook").GetComponent<rulebookMovement>().spriteCount == 7))
                //{
                //    if ((transform.position.z + 0.1f) >= 7 && transform.position.z <= 8)
                //    {
                //        corrects[7] = "rulebookkukyo";

                //    }
                //    else if ((transform.position.z + 0.1f) >= 8 && transform.position.z <= 9)
                //    {
                //        corrects[8] = "rulebookhasegawa";
                //    }
                //    else
                //    {
                //        corrects[9] = "rulebookkixin";
                //    }
                //}
                // yo future adrian get this done ^
                // it's just the names of the towns

                //ok
                //it done
                //Debug.Log(corrects[8]);
            }
            else if ((transform.position.z + 0.1f) >= 12 && transform.position.z <= 16)
            {
                nameOfPlace = "Passport";
            }
            else if ((transform.position.z + 0.1f) >= 17 && transform.position.z <= 21)
            {
                nameOfPlace = "ID";
            }
            whatThisIs = corrects[(int)(transform.position.z + 0.1f)];
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().size = new Vector2(Size[(int)(transform.position.z + 0.1f) * 2], Size[(int)((transform.position.z + 0.1f) * 2) + 1]);
            transform.position = new Vector3(GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.x + transform.position.x, GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.y + transform.position.y, -3);
            runsTimes = true;

        }
    }
}
