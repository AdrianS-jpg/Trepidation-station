using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sprite monster;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = monster;
    }
}
