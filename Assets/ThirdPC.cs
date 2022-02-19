using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPC : MonoBehaviour
{
    public Vector2 _look;
    public GameObject freeLookCam;
    float moveSpeed= 7f;
    public float rotationPower = 3f;
    Vector3 moveDir = Vector3.zero;
    Vector3 gravityDir = Vector3.zero;
    CharacterController controller;
    float gravity = 8f;
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Walk()
    {
        if(Input.GetKey(KeyCode.W))
        {
            moveDir = new Vector3(0,0,1);
            moveDir *= moveSpeed;
            moveDir = this.transform.TransformDirection(moveDir);
            controller.Move(moveDir * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.S))
        {
           moveDir = new Vector3(0,0,-1);
           moveDir *= moveSpeed;
           moveDir = this.transform.TransformDirection(moveDir);
           controller.Move(moveDir * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
           moveDir = new Vector3(1,0,0);
           moveDir *= moveSpeed;
           moveDir = this.transform.TransformDirection(moveDir);
           controller.Move(moveDir * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
           moveDir = new Vector3(-1,0,0);
           moveDir *= moveSpeed;
           moveDir = this.transform.TransformDirection(moveDir);
           controller.Move(moveDir * Time.deltaTime);
        }
    }

    private void rotateCharacter()
    {
        transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y, Vector3.up);
    }

    private void applyGravity()
    {
        //apply gravity
        gravityDir.y -= gravity * Time.deltaTime;
        controller.Move(gravityDir);
    }
    
    // Update is called once per frame
    void Update()
    {
        Walk();
        rotateCharacter();
        applyGravity();
        Cursor.lockState = CursorLockMode.Locked;
        //lock cursor to the middle of the screen
    }
}
