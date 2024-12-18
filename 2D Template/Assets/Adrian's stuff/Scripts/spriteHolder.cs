using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spriteHolder : MonoBehaviour
{
    struct rulebookSprites
    {
        
    }
    public Sprite rulebookDefault, rulebookMap, rulebook1, rulebook2, rulebook3, rulebook4, rulebook5, rulebook6, rulebook7, rulebook8, rulebook9, rulebookCover, rulebookCoreander, rulebookDerekstad, rulebookIchkersk, rulebookKeiraland, rulebookKunitri, rulebookDocuments;
    public Sprite passportKunitri, passportKunitriOpen, passportCoreander, passportCoreanderOpen, passportDerekstad, passportDerekstadOpen, passportIchkersk, passportIchkerskOpen, passportKeiraland, passportKeiralandOpen;
    public List<Sprite> rulebookSpriteList;
    public List<Sprite> passportSpriteList;
    // Start is called before the first frame update
    void Start()
    {
        rulebookSpriteList.Add(rulebookDefault);
        rulebookSpriteList.Add(rulebookMap);
        rulebookSpriteList.Add(rulebook1);
        rulebookSpriteList.Add(rulebookCoreander);
        rulebookSpriteList.Add(rulebookDerekstad);
        rulebookSpriteList.Add(rulebookIchkersk);
        rulebookSpriteList.Add(rulebookKeiraland);
        rulebookSpriteList.Add(rulebookKunitri);
        rulebookSpriteList.Add(rulebookDocuments);
        rulebookSpriteList.Add(rulebookCover);
        passportSpriteList.Add(passportKunitri);
        passportSpriteList.Add(passportKunitriOpen);
        passportSpriteList.Add(passportCoreander);
        passportSpriteList.Add(passportCoreanderOpen);
        passportSpriteList.Add(passportDerekstad);
        passportSpriteList.Add(passportDerekstadOpen);
        passportSpriteList.Add(passportIchkersk);
        passportSpriteList.Add(passportIchkerskOpen);
        passportSpriteList.Add(passportKeiraland);
        passportSpriteList.Add(passportKeiralandOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
