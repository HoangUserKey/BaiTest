using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveDir;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(h, 0, v).normalized;

        HandleAnimation();
        HandleRotation();
    }

    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveDir * moveSpeed * Time.fixedDeltaTime
        );
    }

    void HandleRotation()
    {
        if (moveDir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(moveDir);

            rb.rotation = Quaternion.Slerp(
                rb.rotation,
                rot,
                10f * Time.deltaTime
            );
        }
    }

    void HandleAnimation()
    {
        if (moveDir != Vector3.zero)
        {
            animator.Play("a_Running");
        }
        else
        {
            animator.Play("a_Idle");
        }
    }
}
