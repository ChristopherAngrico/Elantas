using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed;

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
