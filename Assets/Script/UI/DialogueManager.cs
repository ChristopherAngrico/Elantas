using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] text;

    private bool next;
    private bool NPC1;

    private int NPC1Index;
    private int NPC2Index;

    [Header("NPC1")]
    [SerializeField] private DialogueScriptableObject dialogueNPC1;

    [Header("NPC2")]
    [SerializeField] private DialogueScriptableObject dialogueNPC2;

    private float characterPerSecond = 0.05f;

    private void Start()
    {
        text[0].text = string.Empty;
        text[1].text = string.Empty;

        StartCoroutine("NPC1Text");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && next)
        {
            if (NPC1)
            {
                NPC1 = false;
                if (NPC1Index < 3)
                {
                    NPC1Index++;
                    StartCoroutine("NPC1Text");
                }
                else
                {
                    StopCoroutine("NPC1Text");
                }
            }
            else
            {
                NPC1 = true;
                if (NPC2Index < 3)
                {
                    StartCoroutine("NPC2Text");
                    NPC2Index++;
                }
                else
                {
                    StopCoroutine("NPC2Text");
                }
            }
        }
    }

    private IEnumerator NPC1Text()
    {
        text[0].text = string.Empty;
        foreach (char c in dialogueNPC1.dialogue[NPC1Index])
        {
            next = false;
            text[0].text += c;
            yield return new WaitForSeconds(characterPerSecond);
            next = true;
        }
    }

    private IEnumerator NPC2Text()
    {
        text[1].text = string.Empty;
        foreach (char c in dialogueNPC2.dialogue[NPC2Index])
        {
            next = false;
            text[1].text += c;
            yield return new WaitForSeconds(characterPerSecond);
            next = true;
        }
    }
}
