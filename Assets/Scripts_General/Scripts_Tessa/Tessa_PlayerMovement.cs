using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tessa_PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 10f;
    private float gravity = -9.81f;
    public float gravityWeight = 2f;
    public float jumpheight = 2f;

    public Vector3 velocity;
    float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0 && z != 0){
            x = x * 0.5f;
        }
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space) && (Time.time - lastTime > 1.0f)){
            velocity.y = Mathf.Sqrt(jumpheight * 2f * -gravity * gravityWeight);
            lastTime = Time.time;
        } else {
            velocity.y += gravity * gravityWeight * Time.deltaTime;
        }
     
        controller.Move(velocity * Time.deltaTime); 
    }

}
