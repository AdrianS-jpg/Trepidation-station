
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private SlowTalk slowTalk;

    private void Start()
    {
        slowTalk = GetComponent<SlowTalk>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(routine: StepThroughDialogue(dialogueObject));

    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return slowTalk.Run(dialogue, textLabel);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));              // This is if we want it to be an input for the next dialogue instead of it ending and going to the next piece.
            yield return new WaitForSeconds(2);

        }
        

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        
        textLabel.text = string.Empty;
    }
}
