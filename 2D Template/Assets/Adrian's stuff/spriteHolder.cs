using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spriteHolder : MonoBehaviour
{
    public Sprite sprite;
    public List<Sprite> rulebookSprites;
    public List<Sprite> sprites2;
    public List<Sprite> sprites3;
    // Start is called before the first frame update
    void Start()
    {
        rulebookSprites.Add(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
