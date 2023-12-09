using UnityEngine.UI;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    public GameObject quiz;

    [HideInInspector] public bool correctAnswer;
    [HideInInspector] public bool wrongAnswer;

    public delegate void Quiz();
    public static event Quiz OnStartQuiz;
    private void Update()
    {
        if (quiz.activeSelf == true)
        {
            print("Testing");
            OnStartQuiz?.Invoke();
        }
        if (correctAnswer || wrongAnswer)
        {
            quiz.SetActive(false);

            correctAnswer = false;
            wrongAnswer = false;
        }
    }
}
