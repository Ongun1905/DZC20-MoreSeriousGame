using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float t;
    MovingRocks movingRocks;
    MovingTree movingTree;
    
    // Start is called before the first frame update
    void Start()
    {
        t = 1;
        movingRocks = GameObject.Find("FallingRocks").GetComponent<MovingRocks>();
        movingTree = GameObject.Find("FallenTree").GetComponent<MovingTree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y)){ // play back time
            movingRocks.reversedTime = true;
            movingTree.reversedTime = true;
        } else if (Input.GetKey(KeyCode.U)){ // make time slower
            movingRocks.reversedTime = false;
            movingTree.reversedTime = false;
            if(t>=2){
                t-=1;
            }
        } else if (Input.GetKey(KeyCode.I)){ // make time faster
            movingRocks.reversedTime = false;
            movingTree.reversedTime = false;
            t+=1;
        } else if(Input.GetKey(KeyCode.O)){ // pause time
            movingRocks.reversedTime = false;
            movingTree.reversedTime = false;
            t=0;
        } else if(Input.GetKey(KeyCode.P)){ // play time (forward)
            movingRocks.reversedTime = false;
            movingTree.reversedTime = false;
            t=1;
        }
    }

}
