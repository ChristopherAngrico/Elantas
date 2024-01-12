using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] private GameObject LoseUI;

    private void OnEnable()
    {
        Movement.OnDeath += OnDeath;
        DialogueManager.OnGameEnd += GameEnd;
    }

    private void OnDisable()
    {
        Movement.OnDeath -= OnDeath;
        DialogueManager.OnGameEnd -= GameEnd;
    }

    private void OnDeath()
    {
        LoseUI.SetActive(true);
    }

    private void GameEnd()
    {
        StartCoroutine("Delay");
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        LoseUI.SetActive(true);
    }
}
