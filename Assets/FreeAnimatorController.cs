using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeAnimatorController : MonoBehaviour
{
    Animator animator;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void animateWalk()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Walk", 1);
            }
            if (!Input.GetKey(KeyCode.W)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Walk", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animateWalk();
    }
}
