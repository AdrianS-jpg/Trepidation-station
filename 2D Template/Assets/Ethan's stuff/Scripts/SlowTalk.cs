using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowTalk : MonoBehaviour          // To make this note short, it allows you to change the speed of the dialogue.
{
   [SerializeField] public float talkingSpeed = 50f;
   public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(routine:TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * talkingSpeed;
                charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);

            textLabel.text = textToType.Substring(startIndex:0, length:charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
    



}
