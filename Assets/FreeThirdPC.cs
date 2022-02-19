using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeThirdPC : MonoBehaviour
{
    public GameObject freeLookCam;
    float moveSpeed= 3.5f;
    Vector3 moveDir = Vector3.zero;
    Vector3 gravityDir = Vector3.zero;
    CharacterController controller;
    float gravity = 8f;

    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void rotateToCamera()
    {
        // W only
        if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y, Vector3.up);
        }

        // A only
        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y+270f, Vector3.up);
        }

        // S only
        if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y+180f, Vector3.up);
        }

        // D only
        if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y+90f, Vector3.up);
        }

        //W combinations
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y + 315f, Vector3.up);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y + 45f, Vector3.up);
        }

        //S combinations
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y + 225f, Vector3.up);
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.AngleAxis(freeLookCam.transform.eulerAngles.y + 135f, Vector3.up);
        }
    }

    void Walk()
    {
        if(Input.GetKey(KeyCode.W))
        {
            //set direction relative to camera
            moveDir = freeLookCam.transform.forward;
            moveDir *= moveSpeed;
            controller.Move(moveDir * Time.deltaTime);
        }    

        if(Input.GetKey(KeyCode.S))
        {
            moveDir = freeLookCam.transform.forward;
            moveDir *= -moveSpeed;
            controller.Move(moveDir * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            moveDir = freeLookCam.transform.right;
            moveDir *= -moveSpeed;
            controller.Move(moveDir * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            moveDir = freeLookCam.transform.right;
            moveDir *= moveSpeed;
            controller.Move(moveDir * Time.deltaTime);
        }
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
        applyGravity();
        rotateToCamera();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
