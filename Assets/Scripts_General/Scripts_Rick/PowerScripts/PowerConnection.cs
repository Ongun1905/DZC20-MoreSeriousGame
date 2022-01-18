using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConnection : MonoBehaviour
{

    public Transform connected_Object; // Holds the transform of the connected object
    public bool PULSE = false; // If the object starts transferring power it will check if this value is true for each connection to check if the power should originate from that connection
    //In Short:
    //PULSE = TRUE ---> Connection is output (and also input)
    //PULSE = FALSE ---> Connection is only input
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
