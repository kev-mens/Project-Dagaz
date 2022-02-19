using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //increases performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //if player presses w key
        // isWalking in if-statement prevents setting value every frame
        if (!isWalking && forwardPressed)
        {
            //then set isWalking to true
            animator.SetBool(isWalkingHash, true);
        }

        //if player is not pressing w key
        if (isWalking && !forwardPressed)
        {
            //then set isWalking to false
            animator.SetBool(isWalkingHash, false);
        }

        // if the player is walking and not running and pressing LSHIFT
        if (!isRunning && forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }

        // if the player is running and stops pressing w or LSHIFT
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

    }
}
