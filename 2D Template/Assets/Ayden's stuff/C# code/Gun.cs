using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public UnityEvent Onclick;
    private void OnMouseUp()
    {
        Onclick.Invoke();
    }
}
