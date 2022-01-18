using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRocks : MonoBehaviour
{
    Vector3 p0;
    Vector3 p1;
    float speed; // higher is faster
    TimeControl timeControl;
    public bool reversedTime;

    // Start is called before the first frame update
    void Start()
    {
        p0 = transform.position;
        p1 = new Vector3(-52f, 22f, 52f);
        speed = 3f;
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
        reversedTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        float tc = timeControl.t;
        float t = Time.deltaTime * speed * tc;
        if(reversedTime){
            transform.position = Vector3.MoveTowards(transform.position, p1, t);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, p0, t);
        }
    }

}
