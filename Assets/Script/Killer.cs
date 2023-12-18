using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    private bool move;
    private float speed = 1;
    private void OnEnable()
    {
        Movement.OnStartQuiz += () =>
        {
            move = true;
        };
        OptionManager.OnEndQuiz += () =>
        {
            move = false;
        };
    }
    private void Update()
    {
        if (!move) return;
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        move = false;
    }
}
