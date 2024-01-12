using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight : MonoBehaviour
{
    private Button button;
    public delegate void TrafficLightDelegate();
    public static event TrafficLightDelegate OnStopVehicle;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.enabled = false;

        DialogueManager.OnGameStart += GameStart;
        CountDownManager.OnStartQuiz += OnQuiz;
        OptionManager.OnEndQuiz += OnEndQuiz;
    }

    private void OnDisable()
    {
        DialogueManager.OnGameStart -= GameStart;
    }

    public void GameStart()
    {
        button.enabled = true;
    }

    private void OnQuiz()
    {
        button.enabled = false;
    }

    private void OnEndQuiz(int n)
    {
        button.enabled = true;
    }

    public void StopVehicle()
    {
        OnStopVehicle?.Invoke();
    }

}
