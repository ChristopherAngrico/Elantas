using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    private float countDownInit;
    private float countDown;

    [SerializeField] private TextMeshProUGUI text;

    private bool triggerCountdown;
    private bool startQuiz;

    public delegate void Quiz();
    public static event Quiz OnStartQuiz;

    public delegate void ReduceHealth();
    public static event ReduceHealth OnReduceHealth;

    private void OnEnable()
    {
        text.text = string.Empty;

        countDown = countDownInit;

        OptionManager.OnEndQuiz += EndAQuiz;

        OptionManager.OnAnswer += Answer;

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

    private void Answer(int value)
    {
        countDownInit += value;
        countDown = countDownInit;
        text.text = countDownInit.ToString();
    }

    private void EndAQuiz()
    {
        triggerCountdown = true;
        text.enabled = true;
        startQuiz = true;
    }

    private void OnDisable()
    {
        OptionManager.OnEndQuiz -= EndAQuiz;

        OnStartQuiz -= StartAQuiz;
    }

    private void FixedUpdate()
    {
        if (!triggerCountdown) return;

        // Timer count down
        countDown -= Time.deltaTime;
        int current = Mathf.FloorToInt(countDown) + 1;
        countDownInit = current;
        if (current < 0)
        {
            countDownInit = 0;
            return;
        }

        text.text = current.ToString();

        //Enable Quiz
        if (current == 0 && startQuiz)
        {
            OnReduceHealth?.Invoke();
            OnStartQuiz?.Invoke();
            startQuiz = false;
        }
    }
}
