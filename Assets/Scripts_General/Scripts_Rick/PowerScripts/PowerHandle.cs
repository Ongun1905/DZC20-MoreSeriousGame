using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHandle : MonoBehaviour
{

    [Range(0.0F, 1F)]public float updatefrequency = 1F; //The amound of time (seconds) between each update
    private float lastUpdate = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lastUpdate = lastUpdate + Time.deltaTime;

        if(lastUpdate > updatefrequency){
            foreach(Transform child in transform){
                foreach(Transform component in child){
                        component.GetComponent<PowerUpdate>().UPDATE = true;
                }
            }
            lastUpdate = 0;
        }
    }
}
