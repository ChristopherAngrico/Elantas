using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private float countDownInit;
    private float countDown;

    [SerializeField] private TextMeshProUGUI text;

    private bool triggerCountdown;
    private bool startQuiz;

    public delegate void Quiz();
    public static event Quiz OnStartQuiz;

    private void OnEnable()
    {
        text.text = string.Empty;

        countDown = countDownInit;

        OptionManager.OnEndQuiz += EndAQuiz;

        DialogueManager.OnGameStart += GameStart;

        OnStartQuiz += StartAQuiz;
    }

    private void GameStart()
    {
        text.text = "0";
    }

    private void StartAQuiz()
    {
        triggerCountdown = false;
        text.enabled = true;
        startQuiz = false;
    }

    private void EndAQuiz(int n)
    {
        triggerCountdown = true;
        text.enabled = true;
        countDown += 2;
        startQuiz = true;
    }

    private void OnDisable()
    {
        OptionManager.OnEndQuiz -= EndAQuiz;

        OnStartQuiz -= StartAQuiz;
    }

    private void FixedUpdate()
    {

        if (!triggerCountdown)
        {
            countDown = countDownInit;
            return;
        }

        // Timer count down
        countDown -= Time.deltaTime;
        int current = Mathf.FloorToInt(countDown);
        countDownInit = current + 1;
        if (current < 0)
        {
            countDownInit = 0;
            return;
        }

        text.text = current.ToString();
            
        //Enable Quiz
        if (current == 0 && startQuiz)
        {
            OnStartQuiz?.Invoke();
            startQuiz = false;
        }
    }
}
