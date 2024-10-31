using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMoving : MonoBehaviour
{
    [SerializeField] private float speed = 5f;


    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(0, -speed * Time.fixedDeltaTime, 0));
    }
}
