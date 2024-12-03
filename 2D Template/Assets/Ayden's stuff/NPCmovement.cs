using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    public enum Location { Traveling, Accepted, Denied, Middle}
    public Transform centerscreen;
    public Transform Denied;
    public Transform Accepted;
    public Location location = Location.Traveling;
    public float speed = 3f;
    public float wspeed;
    public float frequency;
    public float amplitude;
    float xPos;
    float yPos;
    //public bool inMiddle;
    //public bool accept;
    //public bool deny;

    void Start()
    {
        xPos = transform.position.x; 
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(location);
        if (location == Location.Traveling)
        {
           transform.position = Vector2.MoveTowards(transform.position, centerscreen.position, speed * Time.timeScale);
            if (transform.position == centerscreen.position)
            {
                location = Location.Middle;

            }
        }
        if (location == Location.Accepted)
        {
            transform.position = Vector2.MoveTowards(transform.position, Accepted.position, speed * Time.timeScale);
        }
        if (location == Location.Denied)
        {
            transform.position = Vector2.MoveTowards(transform.position, Denied.position, speed * Time.timeScale);
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
        } 
    }
    public void denyer()
    {
        if (location == Location.Middle)
        {
            location = Location.Denied;
        }
    }

    public GameObject monster;
    public List<Sprite> allMonsters;

    public void Call()
    {
        if (location == Location.Accepted)
        {
            //monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }
        else if (location == Location.Denied)
        {
            //monster.GetComponent<SpriteRenderer>().sprite = allMonsters[Random.Range(0, allMonsters.Count)];
            transform.position = new Vector2(-11.2f, 0);
            location = Location.Traveling;
        }

    }
}