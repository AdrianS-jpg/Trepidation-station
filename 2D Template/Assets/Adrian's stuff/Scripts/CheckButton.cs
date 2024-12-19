using JetBrains.Annotations;
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
        0.02025991f, 0.007444256f, 
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
        0.01803832f, 0.01869354f,
        0.03211192f, 0.006273255f,
        0.03211192f, 0.005332447f,
        0.03211192f, 0.005332447f,
        0.03211192f, 0.005332447f}; //and here too
    public string nameOfPlace;
    public static List<string> corrects = new List<string>() {"correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct"};
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

    }

    void OnMouseDown()
    {
        GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add(whatThisIs);
    }
    public void whenPressed()
    {

    }
    public void placeEverything()
    {
        if (runsTimes == false)
        {
            //new idea: computer knows where to put boxes because of original vector in which it is spawned into, the (x, y, z) coordinate bc it changes immiedently. 
            //or just use the vector itself as the coordinates
            //i might be both stupid and smart at the same time chat
            //GetComponent<Renderer>().enabled = true;
            Debug.Log(transform.position.z);
            if ((transform.position.z + 0.1f) >= 0 && transform.position.z <= 11)
            {
                nameOfPlace = "Rulebook";
            }
            else if ((transform.position.z + 0.1f) >= 12 && transform.position.z <= 16)
            {
                nameOfPlace = "Passport";
            }
            whatThisIs = corrects[(int)(transform.position.z + 0.1f)];
            Debug.Log(whatThisIs);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().size = new Vector2(Size[(int)(transform.position.z + 0.1f) * 2], Size[(int)((transform.position.z + 0.1f) * 2) + 1]);
            transform.position = new Vector3(GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.x + transform.position.x, GameObject.Find(nameOfPlace).GetComponent<Transform>().transform.position.y + transform.position.y, -3);
            runsTimes = true;

        }
    }
}
