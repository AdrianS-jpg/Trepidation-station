using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GunFinal : MonoBehaviour
{
    public UnityEvent Onclick;
    private void OnMouseDown()
    {
        Onclick.Invoke();
    }
}
