using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPasstrough : MonoBehaviour
{

    PowerObject PowerObject;
    PowerLine PowerLine;
    PowerConnection PowerConnection;

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
            ManageConnections();
            PowerObject.PulseConnections(PowerObject.Connections, null);
        }
    }

    void ManageConnections(){

        foreach(Transform child in transform.parent.transform){
            if(child.name.Equals("connection 0") || child.name.Equals("connection 3")){
                if(child.name.Equals("connection 0")){
                    PowerLine = child.GetComponent<PowerLine>();
                    if(PowerLine != null){
                        PowerConnection = PowerLine.GetComponent<PowerConnection>();
                        PowerObject.Connections.Find(child.name).GetComponent<PowerConnection>().PULSE = PowerLine.POWERED;
                        transform.Find("arrow 0").GetComponent<PowerArrow>().UpdateArrow(PowerLine.POWERED);
                    }
                }
                else{
                    PowerLine = child.GetComponent<PowerLine>();
                    if(PowerLine != null){
                        PowerConnection = PowerLine.GetComponent<PowerConnection>();
                        PowerObject.Connections.Find(child.name).GetComponent<PowerConnection>().PULSE = PowerLine.POWERED;
                        transform.Find("arrow 3").GetComponent<PowerArrow>().UpdateArrow(PowerLine.POWERED);
                    }
                }
            }
        }

    }


}
