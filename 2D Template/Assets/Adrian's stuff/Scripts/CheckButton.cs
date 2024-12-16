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
    public static List<float> Size = new List<float>() { 0.02025991f, 0.007444256f, 0.01097764f, 0.005743125f, 0.01305398f, 0.005743125f, 0.008274899f, 0.002899706f, 0.01515058f, 0.003617398f }; //and here too
    public static List<string> corrects = new List<string>() {"correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct", "correct"};
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
        if (GameObject.Find("Passport").GetComponent<WhenClicked>().redMode == true) 
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
            if (transform.localPosition.z >= 0 && transform.localPosition.z <= 11)
            {
                whatThisIs = corrects[(int) transform.localPosition.z];
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<BoxCollider2D>().size = new Vector2(Size[(int) transform.localPosition.z * 2], Size[(int) (transform.localPosition.z * 2) + 1]);
                transform.position = new Vector3(GameObject.Find("Rulebook").GetComponent<Transform>().transform.position.x + transform.localPosition.x, GameObject.Find("Rulebook").GetComponent<Transform>().transform.position.y + transform.localPosition.y, -3);
                runsTimes = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
                //GetComponent<BoxCollider2D>().size = new Vector2(Size[placementnumberInList], Size[placementnumberInList + 1]);
                //transform.position = new Vector3(obj.GetComponent<Transform>().transform.position.x + placements[placementnumberInList], obj.GetComponent<Transform>().transform.position.y + placements[placementnumberInList + 1], obj.GetComponent<Transform>().transform.position.z);
                runsTimes = true;
            }

        }
    }
}
