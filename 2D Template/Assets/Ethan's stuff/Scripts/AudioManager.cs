using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    private void Awake()
    {
      if (instance)
      {
            instance = this;

            DontDestroyOnLoad(gameObject);
      }
      else
      {
            Destroy(gameObject);
      }
    }
}
