using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;

    List<GameObject> tempResponseButtons = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();       //Grabs the DiaUI
    }
    public void ShowResponses(Responses[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Responses response in responses)            //Code that retrieves the responses
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(call: () => OnPickedResponse(response));

            tempResponseButtons.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, y: responseBoxHeight);
        responseBox.gameObject.SetActive(true);
    }  

    private void OnPickedResponse(Responses response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)
        {
            Destroy(button);                     // This destroys the button when the dialogue ends if there is no response.
        }
        tempResponseButtons.Clear();                // Clears after all the responses are done

        dialogueUI.ShowDialogue(response.DiaLogueObject);



    }


}
