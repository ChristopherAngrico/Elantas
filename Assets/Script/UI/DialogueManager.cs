using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject NPC;
    [SerializeField] private TextMeshProUGUI[] text;

    private bool next;
    [Tooltip("Turning off is to set up for checking dialogue manager finish")]
    private bool turnOff;

    private int NPC1Index;
    private int NPC2Index;

    [Header("NPC1")]
    [SerializeField] private DialogueScriptableObject dialogueNPC1;

    [Header("NPC2")]
    [SerializeField] private DialogueScriptableObject dialogueNPC2;

    public delegate void GameEvent();
    public static event GameEvent OnGameStart;
    public static event GameEvent OnGameEnd;

    [SerializeField] private float characterPerSecond = 0.05f;

    private void OnEnable()
    {

        text[0].text = string.Empty;
        text[1].text = string.Empty;

        StartCoroutine("NPC1Text");
        NPC1Index++;

        HealthManager.OnFail += Fail;
    }

    private void OnDisable()
    {
        HealthManager.OnFail -= Fail;
    }

    private void Fail()
    {
        text[0].text = string.Empty;
        text[1].text = string.Empty;
        NPC.SetActive(true);
        StartCoroutine("NPC1Text");
    }

    private void Update()
    {
        if (text[1].text == dialogueNPC2.dialogue[NPC2Index])
        {
            turnOff = true;
            if (NPC2Index == 1)
            {
                OnGameEnd?.Invoke();
                return;
            }
            StopAllCoroutines();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (next)
            {
                StartCoroutine("NPC2Text");
                next = false;
            }
            if (turnOff)
            {
                turnOff = false;
                NPC.SetActive(false);

                OnGameStart?.Invoke();
                NPC2Index++;
            }
        }
    }

    private IEnumerator NPC1Text()
    {
        text[0].text = string.Empty;
        foreach (char c in dialogueNPC1.dialogue[NPC1Index])
        {
            text[0].text += c;
            yield return new WaitForSeconds(characterPerSecond);
        }
        next = true;
    }

    private IEnumerator NPC2Text()
    {
        text[1].text = string.Empty;
        foreach (char c in dialogueNPC2.dialogue[NPC2Index])
        {
            text[1].text += c;
            yield return new WaitForSeconds(characterPerSecond);
        }
    }
}
