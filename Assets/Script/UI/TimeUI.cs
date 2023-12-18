using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private float countDownInit;
    private float countDown;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator animator;
    [SerializeField] private bool triggerCountdown;
    private void OnEnable()
    {
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
            countDown = countDownInit;
        }
        else
        {
            animator.speed = 1;
            countDown -= Time.deltaTime;
            int current = Mathf.FloorToInt(countDown);
            if (countDown < 0) return;
            text.text = current.ToString();
            print(current);
        }
    }
}
