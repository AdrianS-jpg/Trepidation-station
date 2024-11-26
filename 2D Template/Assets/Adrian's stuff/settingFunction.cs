using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingFunction : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>(); 
    public List<string> pattern = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void drop()
    {
        int nc = Random.Range(1, 6);
        if (nc < 6)
        {
            pattern.Add("correct");
        }
        else
        {
            pattern.Add("incorrect");
        }
    }
}
