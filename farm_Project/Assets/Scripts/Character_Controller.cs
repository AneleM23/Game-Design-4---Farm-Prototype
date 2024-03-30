using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character_Controller : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    Animator animator;
    public bool moving;

    public Vector2 lastMotionVector;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");


        motionVector = new Vector2(horizontal, vertical);
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("Moving", moving);
        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("LastHorizontal", horizontal);
            animator.SetFloat("LastVertical", vertical);
        }


    }
    private void Move()
    {
        rigidbody2D.velocity = motionVector * speed;
    }
}