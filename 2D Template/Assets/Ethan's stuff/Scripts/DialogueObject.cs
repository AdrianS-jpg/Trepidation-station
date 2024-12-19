using UnityEngine;


    [CreateAssetMenu(menuName = "Dialogue/DialogueObject" )]
public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] private Responses[] responses; 

    public string[] Dialogue => dialogue;

    public Responses[] Responses => responses;
}
