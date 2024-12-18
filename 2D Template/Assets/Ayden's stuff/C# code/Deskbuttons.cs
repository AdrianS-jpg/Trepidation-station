using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Deskbuttons : MonoBehaviour
{
    public bool deskLight = false;
    public bool gun = false;
    public UnityEvent lightOn;
    public UnityEvent lightOff;
    public UnityEvent gunOn;
    public UnityEvent gunOff;
    public UnityEvent LightGunOn;
    // Start is called before the first frame update
    public void Light_switch()
    {
        if (deskLight == false) 
        {
            deskLight = true;
            lightOn.Invoke();
        }
        else if (deskLight == true)
        {
            deskLight = false;
            if (gun == true)
            {
                gunOn.Invoke();
            }
            else
            {
                lightOff.Invoke();
            }
        }

    }
    public void Gun_out()
    {
        if (gun == false)
        {
            gun = true;
            gunOn.Invoke();
        }
        else if (gun == true)
        {
            gun = false;
            if (deskLight == true)
            {
                lightOn.Invoke();
            }
            else
            {
                gunOff.Invoke();
            }
            
        }

    }
    public void light_gun()
    {
        if (gun == true && deskLight == true)
        {
            LightGunOn.Invoke();
        }
    }
    public void Update()
    {
        light_gun();
    }
}
