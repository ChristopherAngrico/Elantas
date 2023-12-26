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
        OptionManager.OnResetQuestion += (bool testing) => {
            RandomPick();
        };
    }

    private void RandomPick()
    {
        while (true)
        {
            getRandom = Random.Range(0, questionScriptableObject.Length);
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
