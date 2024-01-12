using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector3 moveDirection;
    private bool canMove;

    public delegate void Death();
    public static event Death OnDeath;

    public delegate void Win();
    public static event Win OnWin;

    private void OnEnable()
    {
        OptionManager.OnNextQuiz += NextQuiz;

        CountDownManager.OnStartQuiz += StartAQuiz;

        DialogueManager.OnGameStart += GameStart;
    }

    private void GameStart()
    {
        canMove = true;
    }
    
    private void StartAQuiz()
    {
        canMove = false;
    }

    private void NextQuiz(bool n)
    {
        canMove = n;
    }

    private void OnDisable()
    {
        OptionManager.OnNextQuiz -= NextQuiz;

        CountDownManager.OnStartQuiz -= StartAQuiz;

        DialogueManager.OnGameStart -= GameStart;
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
        if (collision.gameObject.tag == "Finish")
        {
            OnWin?.Invoke();
            canMove = false;
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            OnDeath?.Invoke();
            canMove = false;
            return;
        }
    }
}
