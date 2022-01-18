using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerObject : MonoBehaviour
{

    [Header("Layer")]  //Set the layer where all logic Objects can be found. (Create a new Layer named logic, and add all logic objects to this layer)
    public LayerMask logicLayer;

    [HideInInspector]
    public Transform Connections;

    [HideInInspector]
    public string connection_string = "Connections"; //Name of the Object that holds all of the connection transforms

    public bool DEBUG = false;


    // Start is called before the first frame update
    void Start()
    {
        Connections = transform.Find(connection_string);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulseConnections(Transform connectionTransform, Transform previousObject){

        Transform connectedObject;
        PowerLine connectedPowerline;
        PowerConnection powerConnection;

        foreach(Transform child in connectionTransform.transform){
            powerConnection = child.GetComponent<PowerConnection>();
            if(powerConnection != null){
                if(powerConnection.PULSE){
                    connectedObject = child.GetComponent<PowerConnection>().connected_Object;
                    if(connectedObject != null){
                        if(connectedObject != previousObject){
                        connectedPowerline = connectedObject.GetComponent<PowerLine>();
                            if(connectedPowerline != null){
                                if(!connectedPowerline.POWERED || (connectedPowerline.POWERED && connectedPowerline.lastPower != 0)){
                                    connectedPowerline.POWERED = true;
                                    connectedPowerline.lastPower = 0;
                                    PulseConnections(connectedObject.Find(connection_string), connectionTransform.parent);
                                }
                            }
                        }
                     }
                }
            }
        }

    }

    public Transform GetConnectedObject(Transform connection){
        RaycastHit[] hits;
        Transform closest = null;
        float distance = 0F;

        hits = Physics.RaycastAll(connection.parent.position, new Vector3(connection.position.x - connection.parent.position.x, 0, connection.position.z - connection.parent.position.z).normalized, 1, logicLayer);
        foreach(RaycastHit hit in hits){
            if(hit.transform.parent.parent != connection.parent.parent){
                if(closest == null || distance > hit.distance){
                    closest = hit.transform;
                    distance = hit.distance;
                }
            }
        }

        if(closest != null){
            closest = closest.parent.parent;
        }

        return closest;
    }

    public void UpdateConnections(){

        if(DEBUG){ Debug.Log("Updating Connections for: " + transform.name); }
        foreach(Transform child in Connections.transform){
            child.GetComponent<PowerConnection>().connected_Object = GetConnectedObject(child);
        }

    }

    public bool[] InputStates(){  // Create bool list with the input values of the gate

        Transform connected_Object;
        PowerConnection power_Connection;
        PowerLine connected_PowerLine;

        bool[] inputstates = {false, false};
        int i = 0;

        foreach(Transform child in Connections.transform){
            power_Connection = child.GetComponent<PowerConnection>();
            if(power_Connection != null){
                if(!power_Connection.PULSE){
                    connected_Object = power_Connection.connected_Object;
                    if(connected_Object != null){
                        connected_PowerLine = connected_Object.GetComponent<PowerLine>();
                        if(connected_PowerLine != null){
                            inputstates[i] = connected_PowerLine.POWERED;
                        }
                    }
                }
            }
            i++;
        }

        return inputstates;
    }

    public bool GetGateState(string GateType){ //Returns the state the output should have

        int count = 0;

        bool[] NOT = {true, false, false};
        bool[] AND = {false, false, true};
        bool[] OR = {false, true, true};
        bool[] XOR = {false, true, false};

        foreach(bool state in InputStates()){
            if(state){
                count++;
            }
        }

        if(GateType.Equals("NOT")){ return NOT[count]; }

        if(GateType.Equals("AND")){ return AND[count]; }
        if(GateType.Equals("OR")){ return OR[count]; }
        if(GateType.Equals("XOR")){ return XOR[count]; }

        if(GateType.Equals("NAND")){ return !AND[count]; }
        if(GateType.Equals("NOR")){ return !OR[count]; }
        if(GateType.Equals("NXOR")){ return !XOR[count]; }

        return false;
    }

}
