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

    [Header("Materials")]
    public Material material_NOT;
    public Material material_AND;
    public Material material_OR;
    public Material material_XOR;

    Transform Body;

    // Start is called before the first frame update
    void Start()
    {
        PowerObject = GetComponent<PowerObject>();
        Body = transform.Find("Gate 3D Objects");
        UpdateGateMaterial(type.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PowerUpdate>().UPDATE){
            GetComponent<PowerUpdate>().UPDATE = false;
            PowerObject.UpdateConnections();
            //UpdateGateMaterial(type.ToString());
            if(PowerObject.GetGateState(type.ToString())){
                PowerObject.PulseConnections(PowerObject.Connections, null);
            }
        }
    }

    void UpdateGateMaterial(string GateType){
        foreach(Transform child in Body.transform){
            if(GateType.Equals("AND") || GateType.Equals("NAND")){
                child.GetComponent<MeshRenderer> ().material = material_AND;
            }
            else if(GateType.Equals("OR") || GateType.Equals("NOR")){
                child.GetComponent<MeshRenderer> ().material = material_OR;
            }
            else if(GateType.Equals("XOR") || GateType.Equals("NXOR")){
                child.GetComponent<MeshRenderer> ().material = material_XOR;
            }
            else if(GateType.Equals("NOT")){
                child.GetComponent<MeshRenderer> ().material = material_NOT;
            }
        }
    }

}
