using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick_PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    public float speed = 10f;
    private float gravity = -9.81f;
    public float gravityWeight = 2f;
    public float jumpheight = 2f;

    private bool top;

    public Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        //Debug.Log("X movement: " + x);
        float z = Input.GetAxis("Vertical");
        //Debug.Log("Z movement: " + z);

        if (x != 0 && z != 0) {
            x = x * 0.5f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded) {
            if (velocity.y < 0) {
                velocity.y = -2f;
            }
            if (Input.GetButtonDown("Jump")) {
                velocity.y = Mathf.Sqrt(jumpheight * 2f * -gravity * gravityWeight);
            }
        }
        else {
            velocity.y += gravity * gravityWeight * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.C))
        {
            //gravity *= -1;
            gravityWeight *= -1;
            jumpheight *= -1;
            move *= -1;
            Rotation();
      }
        
    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
       }
       else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }



}


