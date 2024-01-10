using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class GenerateQuestion : MonoBehaviour
{

    [SerializeField] private QuestionScriptableObject[] questionScriptableObject;

    [SerializeField] private Image image;

    private List<int> QuestionList = new List<int>();
    
    private int getRandom;

    [HideInInspector] public int questionID { get; private set; }

    private void OnEnable()
    {

        Random.InitState(System.DateTime.Now.Millisecond);

        //Subscribe to start quiz
        Movement.OnStartQuiz += () =>
        {
            RandomPick();
        };
        OptionManager.OnResetQuestion += (bool testing) =>
        {
            RandomPick();
        };
    }

    private void RandomPick()
    {

        if (QuestionList.Count == questionScriptableObject.Length)
        {
            // All questions have been picked
            // Handle this situation, for example by resetting the QuestionList
            QuestionList.Clear();
        }

        while (true)
        {
            int tempRandom = Random.Range(0, questionScriptableObject.Length);
            getRandom = tempRandom;
            if (!QuestionList.Contains(getRandom))
            {
                break;
            }
        }
        QuestionList.Add(getRandom);
        image.sprite = questionScriptableObject[getRandom].sprite;
        questionID = questionScriptableObject[getRandom].id;
    }
}
