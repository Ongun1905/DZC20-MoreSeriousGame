using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    float rotationSpeed;
    TimeControl timeControl;

    // Start is called before the first frame update
    void Start()
    {
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
        rotationSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float tc = timeControl.t;
        transform.Rotate(new Vector3 (0, Time.deltaTime * rotationSpeed * tc,  0));
    }
}
