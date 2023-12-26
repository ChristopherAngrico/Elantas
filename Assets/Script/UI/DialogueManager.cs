using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private DialogueScriptableObject dialogue;
    private float characterPerSecond = 0.05f;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = string.Empty;
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char c in dialogue.dialogue[0])
        {
            text.text += c;
            yield return new WaitForSeconds(characterPerSecond);
        }
    }
}
