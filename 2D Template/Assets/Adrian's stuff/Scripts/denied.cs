using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denied : MonoBehaviour
{
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true){

        } else 
        {

        }
    }

    public void whenPressedTwo()
    {
        if (active == false)
        {
            active = true;
        } else {
            active = false;
        }
    }

    void OnMouseDown()
    {
        if (active == false){
            // if (other.collider.gameObject.name == hit.collider.gameObject) {

            // }
        }
    }
    void OnCollisionEnter(){
        
    }
}
