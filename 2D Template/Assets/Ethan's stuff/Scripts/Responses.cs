
using UnityEngine;

[System.Serializable]
public class Responses
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;
    
    public string ResponseText => responseText;

    public DialogueObject DiaLogueObject => dialogueObject;



}
