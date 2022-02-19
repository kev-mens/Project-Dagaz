
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void animateJog()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Jog", 1);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetInteger("Jog", 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetInteger("Jog Back", 1);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetInteger("Jog Back", 0);
            }
        }
    }

    void animateStrafe()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Left Strafe", 1);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetInteger("Left Strafe", 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("Right Strafe", 1);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetInteger("Right Strafe", 0);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        animateJog();
        animateStrafe();
    }
}
