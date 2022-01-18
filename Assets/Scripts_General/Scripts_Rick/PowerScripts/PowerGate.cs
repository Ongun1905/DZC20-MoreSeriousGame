using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGate : MonoBehaviour
{
    PowerObject PowerObject;

    public enum GateType{
        NOT,
        AND,
        OR,
        XOR,
        NAND,
        NOR,
        NXOR
    };

    public GateType type;

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
            if(PowerObject.GetGateState(type.ToString())){
                PowerObject.PulseConnections(PowerObject.Connections, null);
            }
        }
    }

}
