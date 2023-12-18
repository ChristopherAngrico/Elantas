using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;
    private void OnEnable()
    {
        OptionManager.OnEndQuiz += () =>
        {
            speed = 0;
        };
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
