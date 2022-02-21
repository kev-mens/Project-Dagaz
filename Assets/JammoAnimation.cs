using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammoAnimation : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 0.1f;
    int VeloctyHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VeloctyHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //acceleration & decceleration
        if (forwardPressed && velocity<5.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if(!forwardPressed && velocity>0.0f)
        {
            velocity -= Time.deltaTime * decceleration;
        }

        // forcefully clamp velocity
        if(!forwardPressed && velocity<0.0f)
        {
            velocity = 0.0f;
        }
        if(forwardPressed && velocity>5.0f)
        {
            velocity = 5.0f;
        }
        

        animator.SetFloat(VeloctyHash, velocity);
    }
}
