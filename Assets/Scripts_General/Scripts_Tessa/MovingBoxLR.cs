using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxLR : MonoBehaviour
{
    Vector3 p0;
    Vector3 p1;
    bool right;
    float speed; // higher is faster
    TimeControl timeControl;

    // Start is called before the first frame update
    void Start()
    {
        p0 = new Vector3(-232.24f, 14.64f, 95.6f);
        p1 = new Vector3(-232.24f, 14.64f, 110f);
        speed = 10f; 
        right = true;
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float tc = timeControl.t;
        float t = Time.deltaTime * speed* tc;

        if(right){
            transform.position = Vector3.MoveTowards(transform.position, p1, t);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, p0, t);
        }
        if(transform.position == p1 || transform.position == p0){
            right = !right;
        }
        
    }
}
