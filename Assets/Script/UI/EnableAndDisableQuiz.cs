using UnityEngine;


public class EnableAndDisableQuiz : MonoBehaviour
{
    [SerializeField] private GameObject quiz;

    public delegate void QuizEvent();

    private void OnEnable()
    {
        OptionManager.OnEndQuiz += EndAQuiz;        
        CountDownManager.OnStartQuiz += StartAQuiz;
        DialogueManager.OnGameStart += GameStart;
        HealthManager.OnFail += Fail;
    }

    private void OnDisable()
    {
        OptionManager.OnEndQuiz -= EndAQuiz;
        CountDownManager.OnStartQuiz -= StartAQuiz;
        DialogueManager.OnGameStart -= GameStart;
    }

    private void EndAQuiz(int n)
    {
        quiz.SetActive(false);
    }

    private void Fail()
    {
        quiz.SetActive(false);
    }

    private void StartAQuiz()
    {
        quiz.SetActive(true);
    }

    private void GameStart()
    {
        quiz.SetActive(true);
    }

}
