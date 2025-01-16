using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Events;

public class NPCmovement : MonoBehaviour
{
    

    public enum Location { Traveling, Accepted, Denied, Middle, GUN}
    public Transform centerscreen;
    public Transform Denied;
    public Transform Accepted;
    public Transform GUN;
    public Location location = Location.Traveling;
    public float speed = 3f;
    public float wspeed;
    public float frequency;
    public float amplitude;
    float xPos;
    float yPos;
    public Deskbuttons targetscript;
    public GameObject monster;
    public List<Sprite> allMonsters;

    public GameObject item;
    public UnityEvent onMiddle;
    //public bool inMiddle;
    //public bool accept;
    //public bool deny;

    void Start()
    {
        GameObject.Find("Circle").GetComponent<settingFunction>().adding();
        monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum - 1].Substring(11, 2))];
        GameObject.Find("Circle").GetComponent<settingFunction>().reset();
        Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
        xPos = transform.position.x; 
        yPos = transform.position.y;
        targetscript = GameObject.Find("Button Manager").GetComponent<Deskbuttons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (location == Location.Traveling)          
        {
           transform.position = Vector2.MoveTowards(transform.position, centerscreen.position, speed * Time.deltaTime);
            if (transform.position == centerscreen.position)
            {
                location = Location.Middle;           // Code that makes it drop the Book and passport etc.

                onMiddle.Invoke();
                DropItem();

            }
        }
        if (location == Location.Accepted && item.gameObject.GetComponent<SpriteRenderer>().enabled) // Monster only moves to the right when accpeted, and the passport is collected 
        {
            transform.position = Vector2.MoveTowards(transform.position, Accepted.position, speed * Time.deltaTime);
        }
        if (location == Location.Denied)           // Monster moves left
        {
            transform.position = Vector2.MoveTowards(transform.position, Denied.position, speed * Time.deltaTime);
        }
        if (location == Location.GUN)
        {
           transform.position = Denied.position;
        }
        //transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * frequency)* wspeed  + yPos);
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        pos.y = sin;

        transform.position = pos;
    }
    public void acceptedd()
    {
        if (location == Location.Middle)
        {
            
            location = Location.Accepted;
            GameObject.Find("Circle").GetComponent<settingFunction>().reset();
        } 
    }
    public void denyer()
    {
        if (location == Location.Middle)
        {
            location = Location.Denied;
            GameObject.Find("Circle").GetComponent<settingFunction>().reset();
        }
    }
    public void Gunner()
    {   
        if (targetscript.gun == true)
        {
            GameObject.Find("Mosin_nagant").transform.localPosition = new Vector3(102, -192, 5);
            if (location == Location.Middle)
            {
                location = Location.GUN;
                GameObject.Find("Circle").GetComponent<settingFunction>().reset();
            }
        }
        /*if (targetscript.gun == false)
        {*/
            GameObject.Find("Mosin_nagant").transform.localPosition = new Vector3(102, -192, 6);
        //}
        
    }

    public void Call()
    {
        if (location == Location.Accepted)
        {
            GameObject.Find("Circle").GetComponent<settingFunction>().adding();
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(11,2))];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }
        else if (location == Location.Denied)
        {
            GameObject.Find("Circle").GetComponent<settingFunction>().adding();
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(11, 2))];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }
        else if (location == Location.GUN)
        {
            GameObject.Find("Circle").GetComponent<settingFunction>().adding();
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Convert.ToInt32(GameObject.Find("Circle").GetComponent<settingFunction>().pattern[GameObject.Find("Circle").GetComponent<settingFunction>().patternNum].Substring(11, 2))];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }

    }


    private GameObject ItemInstance;

    private void DropItem()
    {
        GameObject.Find("Circle").GetComponent<settingFunction>().drop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && location == Location.Accepted ||  location == Location.Denied) //If the monster collides with the item only if they are accepted or denied 
        {
            Debug.Log("monster has passport");
            item.GetComponent<SpriteRenderer>().enabled = false;  
        }
    }
}