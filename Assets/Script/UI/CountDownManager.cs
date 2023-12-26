using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    [SerializeField] private float countDownInit;
    private float countDown;
    private TextMeshProUGUI text;
    private Animator animator;
    private bool triggerCountdown;
    private void OnEnable()
    {

        text = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();

        triggerCountdown = true;
        countDown = countDownInit;

        OptionManager.OnEndQuiz += () =>
        {
            triggerCountdown = true;
            animator.Play("Base Layer.TextAnimation", -1, 0f);
            animator.enabled = true;
            text.enabled = true;
        };

        Movement.OnStartQuiz += () =>
        {
            triggerCountdown = false;
            animator.enabled = false;
            text.enabled = true;
        };
    }

    private void Update()
    {
        
        if (!triggerCountdown)
        {
            //Reset countDown
            countDown = countDownInit;
        }
        else
        {
            //timer count down
            animator.speed = 1;
            countDown -= Time.deltaTime;
            int current = Mathf.FloorToInt(countDown);
            if (countDown < 0) return;
            text.text = current.ToString();
        }
    }
}
