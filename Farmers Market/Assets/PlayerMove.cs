using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private Rigidbody2D rb;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput < 0 && facingRight)
        {
            flip();
        }

        if (moveInput > 0 && !facingRight)
        {
            flip();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

    }
}
