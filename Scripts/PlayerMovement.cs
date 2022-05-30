using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jump_Velocity = 10f;
    [SerializeField] LayerMask layermask;


    Rigidbody2D rb2d;
    Animator animator;
    BoxCollider2D bc2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(speed * inputX * Time.deltaTime, 0);
        transform.Translate(movement);

        animator.SetFloat("Speed", Mathf.Abs(inputX));
        animator.SetFloat("LeftRight", inputX);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            rb2d.velocity = Vector2.up * jump_Velocity;
    
    }

    bool isGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, 0.1f, layermask);
        return raycastHit2d.collider != null;
    }
}
