
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    private void Start()
    {
        GetComponent<SlowTalk>().Run("Hello I am a Jeff main \n are you ready to get team wiped?", textLabel);
    }
}
