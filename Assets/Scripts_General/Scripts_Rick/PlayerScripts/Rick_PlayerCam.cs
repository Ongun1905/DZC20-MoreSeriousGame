using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rick_PlayerCam : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSense = 2f;
    public float mouseX = 0f;
    public float mouseY = 0f;

    [Header("Character Settings")]
    public Transform playerBody;


    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    
    }
}
