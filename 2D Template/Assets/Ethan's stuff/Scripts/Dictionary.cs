using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public struct Dictionary 
{
    public Sprite Monster;

    public List<DialogueObject> Intro, Accept, Denial, PreAttackThreat;
}
