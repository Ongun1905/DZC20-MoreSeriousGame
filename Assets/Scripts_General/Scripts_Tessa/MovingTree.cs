using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTree : MonoBehaviour
{
    Vector3 p0;
    Vector3 pos;
    float speed; // higher is faster
    TimeControl timeControl;
    public bool reversedTime;

    // Start is called before the first frame update
    void Start()
    {
        p0 = transform.position;
        pos = transform.position+new Vector3(-11.9f,18f,0f);
        speed = 10f;
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
        reversedTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        float tc = timeControl.t;
        float t = Time.deltaTime * speed * tc;

        if(reversedTime){
            transform.position = Vector3.MoveTowards(transform.position, pos, t);
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 122), t);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, p0, t);
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 0), t);
        }
    }

}
