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
    public Sprite Bigfoot, Frank, Blink, Phillip, Yanagi, David, Fiona, Ichigo, Mavis, Whiskers, Kumiko, Shigure, Spindler, Rufus, Steve, Lillian, Veronie;
    public Sprite Ticket, BigfootCore, BlinkCore, DavidCore, FionaCore, LillianCore;
    public Sprite FionaItem;
    public Sprite LillianEntry;
    public List<Sprite> rulebookSpriteList;
    public List<Sprite> passportSpriteList;
    public List<Sprite> characterSpriteList;
    public List<Sprite> specialItemSpriteList;
    public List<Sprite> IDSpriteList;
    public List<Sprite> entryCardSpriteList;
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

        passportSpriteList.Add(passportCoreander);
        passportSpriteList.Add(passportCoreanderOpen);
        passportSpriteList.Add(passportDerekstad);
        passportSpriteList.Add(passportDerekstadOpen);
        passportSpriteList.Add(passportIchkersk);
        passportSpriteList.Add(passportIchkerskOpen);
        passportSpriteList.Add(passportKeiraland);
        passportSpriteList.Add(passportKeiralandOpen);
        passportSpriteList.Add(passportKunitri);
        passportSpriteList.Add(passportKunitriOpen);

        characterSpriteList.Add(Bigfoot);
        characterSpriteList.Add(Frank);
        characterSpriteList.Add(Blink);
        characterSpriteList.Add(Phillip);
        characterSpriteList.Add(Yanagi);
        characterSpriteList.Add(David);
        characterSpriteList.Add(Fiona);
        characterSpriteList.Add(Ichigo);
        characterSpriteList.Add(Mavis);
        characterSpriteList.Add(Whiskers);
        characterSpriteList.Add(Kumiko);
        characterSpriteList.Add(Shigure);
        characterSpriteList.Add(Spindler);
        characterSpriteList.Add(Rufus);
        characterSpriteList.Add(Steve);
        characterSpriteList.Add(Lillian);
        characterSpriteList.Add(Veronie);

        IDSpriteList.Add(Ticket);
        IDSpriteList.Add(BigfootCore);
        IDSpriteList.Add(BlinkCore);
        IDSpriteList.Add(DavidCore);
        IDSpriteList.Add(FionaCore);
        IDSpriteList.Add(LillianCore);

        specialItemSpriteList.Add(FionaItem);

        entryCardSpriteList.Add(LillianEntry);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
