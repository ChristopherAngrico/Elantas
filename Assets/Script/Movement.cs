using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 moveDirection;
    private bool canMove = true;
    
    public delegate void StartQuiz();
    public static event StartQuiz OnStartQuiz;


    private void OnEnable()
    {
        OptionManager.OnNextQuestion += (bool canMove) => {
            this.canMove = canMove;
        };
    }

    void Update()
    {
        if (canMove)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.position += moveDirection * 2f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnStartQuiz?.Invoke();
        canMove = false;
        Destroy(collision);
    }

}
