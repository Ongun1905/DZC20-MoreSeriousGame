using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    [Header("Materials")]
    public Material material_off;
    public Material material_on;

    [HideInInspector]
    public bool POWERED = false; //The power state of the PowerLine

    [HideInInspector]
    public float lastPower = 0; //The power state of the PowerLine

    [Range(0.1F, 1F)]public float expectedUpdateFrequency = 1F; //If this frequency is not reached, the wire will turn of..

    Transform Objects; //

    PowerObject PowerObject;

    // !!! Connection transforms should be placed on the opposite side from the connection point
    //     The raycast will go trough the entire line and "range" outside of the line.

    // Start is called before the first frame update
    void Start()
    {
        PowerObject = GetComponent<PowerObject>();
        Objects = transform.Find("3D Objects");
        UpdateMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PowerUpdate>().UPDATE){
            GetComponent<PowerUpdate>().UPDATE = false;
            PowerObject.UpdateConnections();
            UpdateMaterial();
        }

        if(POWERED){
            lastPower = lastPower + Time.deltaTime;
            if(lastPower > expectedUpdateFrequency){
                POWERED = false;
                lastPower = 0;            
            }
        }

    }

    void UpdateMaterial(){
        foreach(Transform child in Objects.transform){
            if(POWERED){
                child.GetComponent<MeshRenderer> ().material = material_on;
                //child.GetComponent<Light>().intensity = 0.1f;
            }
            else{
                child.GetComponent<MeshRenderer> ().material = material_off;
                //child.GetComponent<Light>().intensity = 0f;
            }
        }
    }

}
