using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    Vector3 p0;
    Vector3 p1;
    bool up;
    float speed; // higher is faster
    TimeControl timeControl;

    // Start is called before the first frame update
    void Start()
    {
        p0 = new Vector3(-230.3f, 6f, 172f);
        p1 = new Vector3(-230.3f, 13.1f, 172f);
        speed = 10f; 
        up = true;
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float tc = timeControl.t;
        float t = Time.deltaTime * speed* tc;

        if(up){
            transform.position = Vector3.MoveTowards(transform.position, p1, t);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, p0, t);
        }
        if(transform.position == p1 || transform.position == p0){
            up = !up;
        }
        
    }
}
