using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical2");

        racketDirection = new Vector2(0, directionY).normalized;
    }

    // FixedUpdate is called at a fixed time interval
    void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
