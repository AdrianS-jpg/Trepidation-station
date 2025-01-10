using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sprite monster;
    public float speed;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = monster;

        float random = Random.Range(1, 360);
        float x = Mathf.Sin(random);
        float y = Mathf.Cos(random);

        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y)*speed;

    }
}
