using UnityEngine;

public class EnableAndDisableQuiz : MonoBehaviour
{
    [SerializeField] private GameObject quiz;
    private void OnEnable()
    {
        OptionManager.OnEndQuiz += () =>
        {
            quiz.SetActive(false);
        };
        Movement.OnStartQuiz += () =>
        {
            quiz.SetActive(true);
        };
    }
}
