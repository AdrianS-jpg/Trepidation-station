using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    public Transform centerscreen;
    public Transform Denied;
    public Transform Accepted;
    public float speed = 3f;
    public float wspeed;
    public float frequency;
    public float amplitude;
    float xPos;
    float yPos;
    public bool inMiddle;
    public bool accept;
    public bool deny;

    void Start()
    {
        xPos = transform.position.x; 
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == centerscreen.position)
        {
            inMiddle = true;
        }
        if (inMiddle == false)
        {
           transform.position = Vector2.MoveTowards(transform.position, centerscreen.position, speed);
        }
        else if (inMiddle == true)
        {

        }
        if (accept == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Accepted.position, speed);
        }
        if (deny == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Denied.position, speed);
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
        accept = true;
    }
    public void denyer()
    {
        deny = true;
    }

    public GameObject monster;
    public List<Sprite> allMonsters;

    public void Call()
    {
        //monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
        transform.position = new Vector2(-11.2f, 0);
        inMiddle = false;
        accept = false;
        deny = false;
    }
}