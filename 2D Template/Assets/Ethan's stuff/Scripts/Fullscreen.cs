using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fullscreen : MonoBehaviour
{
   public void Fullscene(bool is_fullscene)
   {
      
        Screen.fullScreen = is_fullscene;

        Debug.Log("Fullscreen is" + is_fullscene);

   }
}
