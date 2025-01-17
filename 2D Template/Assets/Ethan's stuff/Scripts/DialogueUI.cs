
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using System.Linq;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private SlowTalk slowTalk;
    private ResponseHandler responseHandler;

    private void Start()
    {
        slowTalk = GetComponent<SlowTalk>();
        responseHandler = GetComponent<ResponseHandler> ();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);

        textLabel.text = string.Empty;
        StopAllCoroutines();


        StartCoroutine(routine: StepThroughDialogue(dialogueObject));

    }

    public void ShowIntroDialogue(DialogueListObject dialoguelistobject)
    {
        Sprite sprite = GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().sprite;
        Dictionary dictionary = dialoguelistobject.dialogueobjects.First(Monster => Monster.Monster == sprite);
        DialogueObject dialogue = dictionary.Intro[0];

        ShowDialogue(dialogue);
    }

    public void ShowAcceptDialogue(DialogueListObject dialoguelistobject)
    {
        Sprite sprite = GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().sprite;
        Dictionary dictionary = dialoguelistobject.dialogueobjects.First(Monster => Monster.Monster == sprite);
        DialogueObject dialogue = dictionary.Accept[0];

        ShowDialogue(dialogue);
    }

    public void ShowDenialDialogue(DialogueListObject dialoguelistobject)
    {
        Sprite sprite = GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().sprite;
        Dictionary dictionary = dialoguelistobject.dialogueobjects.First(Monster => Monster.Monster == sprite);
        DialogueObject dialogue = dictionary.Denial[0];

        ShowDialogue(dialogue);
    }

    public void ShowPreAttackThreatDialogue(DialogueListObject dialoguelistobject)
    {
        Sprite sprite = GameObject.FindGameObjectWithTag("Monster").GetComponent<SpriteRenderer>().sprite;
        Dictionary dictionary = dialoguelistobject.dialogueobjects.First(Monster => Monster.Monster == sprite);
        DialogueObject dialogue = dictionary.PreAttackThreat[0];

        ShowDialogue(dialogue);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        

        
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return slowTalk.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));              // This is if we want it to be an input for the next dialogue instead of it ending and going to the next piece.
            //yield return new WaitForSeconds(2);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.Responses != null && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
        
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        
        textLabel.text = string.Empty;
    }
}
