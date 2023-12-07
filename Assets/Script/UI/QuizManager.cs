using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    [SerializeField] private GenerateQuestion generateQuestion;
    [SerializeField] private OptionManager optionManager;

    [HideInInspector] public List<int> QuestionList = new List<int>();

    [HideInInspector] public int questionID;

    [HideInInspector] public bool nextQuestion;
    private void Awake()
    {
        instance = this;
    }
}
