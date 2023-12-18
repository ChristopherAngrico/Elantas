using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private AIPath iPath;

    public delegate void StartQuiz();
    public static event StartQuiz OnStartQuiz;

    private void OnEnable()
    {
        iPath = GetComponent<AIPath>();
        OptionManager.OnNextQuestion += (bool canMove) => {
            iPath.canMove = canMove;
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnStartQuiz?.Invoke();
        iPath.canMove = false;
        Destroy(collision);
    }

}
