using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDonut : MonoBehaviour
{
    Vector3 p0;
    Vector3 p1;
    bool up;
    float speed; // higher is faster
    TimeControl timeControl;
    float lastTime;
    GameObject quad;
    float d_eu;
    Vector3 pf;
    float d;
    GameObject logicPlayer;
    GameObject church;

    // Start is called before the first frame update
    void Start()
    {
        p0 = new Vector3(-275.7f, 30.7f, 120.4f);
        p1 = new Vector3(-275.7f, 40.7f, 120.4f);
        speed = 10f; 
        up = true;
        timeControl = GameObject.Find("Levels").GetComponent<TimeControl>();
        lastTime = Time.time;
        quad = GameObject.Find("Quad");
        quad.gameObject.SetActive(false);
        pf = new Vector3(-275.7f, 34.7f, 120.4f);
        logicPlayer = GameObject.Find("LogicPlayer");
        church = GameObject.Find("Church");
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

        Vector3 e = logicPlayer.transform.position;
        Vector3 u = church.transform.position;
        d_eu = Vector3.Distance(u, e);
        d = Vector3.Distance(transform.position, pf);
        if(d > 3f){
            lastTime = Time.time;
        } else if(Time.time - lastTime >= 1.5f && d_eu < 40f){
            quad.gameObject.SetActive(true);
        }
       
    }
}
