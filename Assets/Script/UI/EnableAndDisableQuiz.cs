using UnityEngine;

public class EnableAndDisableQuiz : MonoBehaviour
{
    [SerializeField] private GameObject quiz;
    private void OnEnable()
    {
        Movement.OnStartQuiz += () =>
        {
            quiz.SetActive(true);
        };
    }
}
