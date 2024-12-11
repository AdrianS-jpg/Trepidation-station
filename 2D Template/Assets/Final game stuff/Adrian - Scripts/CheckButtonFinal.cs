using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckButtonFinal : MonoBehaviour
{
    public bool active = false;
    public Transform transform;
    public Sprite sprit;
    public GameObject obj;
    public Camera camera;
    public bool runsTimes = false;
    public static List<GameObject> checkobjects = new List<GameObject>();
    public static List<float> placements = new List<float>() { 0.8f, -0.5f, -1f, -2f };//please for the love of god GET THESE WORKING DUMBASS
    public static List<string> objs = new List<string>() {"Rulebook", "Rulebook", "Rulebook"};//and here
    public static List<float> Size = new List<float>() { 0.01859468f, 0.009756039f, 0.05f, 0.05f }; //and here too
    public static int placementnumberInList = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        camera = Camera.main;
        obj = GameObject.Find(objs[0]);
        placeEverything();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Passport").GetComponent<WhenClickedFinal>().redMode == true) 
        {

            if (GameObject.Find("Circle").GetComponent<settingFunctionFinal>().pattern[0] == "correct") { 

            }
            //if (obj.GetComponent<SpriteRenderer>().sprite == sprit)
            //{

            //}

        }
        else
        {
            Destroy(gameObject);
            runsTimes = false;
            placementnumberInList = 0;
        }
        //Debug.Log(camera.WorldToScreenPoint(transform.position));

    }

    void OnMouseDown()
    {
        //GameObject.Find("Circle").GetComponent<settingFunction>().sprites.Add();
    }
    public void whenPressed()
    {

    }
    public void placeEverything()
    {
        if (runsTimes == false)
        {
            //GetComponent<Renderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().size = new Vector2(Size[placementnumberInList], Size[placementnumberInList + 1]);
            transform.position = new Vector3(obj.GetComponent<Transform>().transform.position.x + placements[placementnumberInList], obj.GetComponent<Transform>().transform.position.y + placements[placementnumberInList + 1], obj.GetComponent<Transform>().transform.position.z);
            runsTimes = true;
            placementnumberInList += 2;
            obj = GameObject.Find(objs[placementnumberInList / 2]);

        }
    }
}
