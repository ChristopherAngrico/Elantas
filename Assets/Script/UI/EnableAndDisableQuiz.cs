using UnityEngine;


public class EnableAndDisableQuiz : MonoBehaviour
{
    [SerializeField] private GameObject[] quiz;
    private int nextQuiz;

    public delegate void EndQuizEvent();
    public static event EndQuizEvent OnEndQuiz;

    private void OnEnable()
    {
        OnEndQuiz += EndAQuiz;
        CountDownManager.OnStartQuiz += StartAQuiz;
        DialogueManager.OnGameStart += GameStart;
        OptionManager.OnNextQuestion += NextQuestion;
        //HealthManager.OnFail += Fail;
    }

    private void OnDisable()
    {
        OnEndQuiz -= EndAQuiz;
        CountDownManager.OnStartQuiz -= StartAQuiz;
        DialogueManager.OnGameStart -= GameStart;
        OptionManager.OnNextQuestion -= NextQuestion;
    }

    private void EndAQuiz()
    {
        quiz[nextQuiz].SetActive(false);
    }

    private void NextQuestion()
    {
        if (nextQuiz < quiz.Length - 1)
        {
            quiz[nextQuiz].SetActive(false);
            nextQuiz++;
            quiz[nextQuiz].SetActive(true);
            print(nextQuiz);
        }
        else
        {
            OnEndQuiz?.Invoke();
        }
    }

    //private void Fail()
    //{
    //    quiz.SetActive(false);
    //}

    private void StartAQuiz()
    {
        nextQuiz = 0;
        quiz[nextQuiz].SetActive(true);
    }

    private void GameStart()
    {
        nextQuiz = 0;
        quiz[nextQuiz].SetActive(true);
    }

}
