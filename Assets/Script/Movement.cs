using Pathfinding;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;

    Vector3 moveDirection;
    private bool canMove;

    public delegate void Death();
    public static event Death OnDeath;

    public delegate void Win();
    public static event Win OnWin;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        EnableAndDisableQuiz.OnEndQuiz += OnEndQuiz;

        CountDownManager.OnStartQuiz += StartAQuiz;

        DialogueManager.OnGameStart += GameStart;
    }

    private void GameStart()
    {
        canMove = false;
    }
    
    private void StartAQuiz()
    {
        canMove = false;
    }

    private void OnEndQuiz()
    {
        canMove = true;
    }


    private void OnDisable()
    {
        CountDownManager.OnStartQuiz -= StartAQuiz;

        DialogueManager.OnGameStart -= GameStart;
    }

    void Update()
    {
        if (canMove)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Animated(moveDirection);
            transform.position += moveDirection * 3f * Time.deltaTime;
        }
    }

    private void Animated(Vector2 direction)
    {
        float x = direction.x;
        float y = direction.y;

        if(x == 0 || y == 0)
        {
            print("Idle");
            animator.SetBool("Idle", true);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
        }
        if (x < 0)
        {
            print("Left");
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
        if(x > 0)
        {
            print("Right");
            animator.SetBool("Right", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
        }
        if(y < 0)
        {
            print("Down");
            animator.SetBool("Down", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Up", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        if (y > 0)
        {
            print("Up");
            animator.SetBool("Up", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            OnWin?.Invoke();
            Destroy(gameObject);
            canMove = false;
            return;
        }
        if (collision.gameObject.tag == "Die")
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            canMove = false;
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
            canMove = false;
            return;
        }
    }
}
