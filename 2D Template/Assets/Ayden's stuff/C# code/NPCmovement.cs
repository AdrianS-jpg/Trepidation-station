using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

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
    //public bool inMiddle;
    //public bool accept;
    //public bool deny;

    void Start()
    {
        monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
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
                location = Location.Middle;
                DropItem();

            }
        }
        if (location == Location.Accepted && item.gameObject.GetComponent<SpriteRenderer>().enabled) // Monster only moves to the right when accpeted, and the passport is collected 
        {
            transform.position = Vector2.MoveTowards(transform.position, Accepted.position, speed * Time.deltaTime);
        }
        if (location == Location.Denied)
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
            Destroy(ItemInstance);
        } 
    }
    public void denyer()
    {
        if (location == Location.Middle)
        {
            location = Location.Denied;
            Destroy(ItemInstance);
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
                Destroy(ItemInstance);
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
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }
        else if (location == Location.Denied)
        {
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }
        else if (location == Location.GUN)
        {
            monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
            Enemy.monster = monster.GetComponent<SpriteRenderer>().sprite;
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }

    }


    private GameObject ItemInstance;

    private void DropItem()
    {
        ItemInstance = Instantiate(item, transform.position, transform.rotation);
        ItemInstance.transform.position = new(0, -3.5f);
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