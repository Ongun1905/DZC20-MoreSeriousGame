using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCube : MonoBehaviour
{
    PowerObject PowerObject;

    // Start is called before the first frame update
    void Start()
    {
        PowerObject = GetComponent<PowerObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PowerUpdate>().UPDATE){
            GetComponent<PowerUpdate>().UPDATE = false;
            PowerObject.UpdateConnections();
            PowerObject.PulseConnections(PowerObject.Connections, null);
        }

    }

}
