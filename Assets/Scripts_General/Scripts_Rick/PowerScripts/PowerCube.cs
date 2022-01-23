using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCube : MonoBehaviour
{
    PowerObject PowerObject;
    public bool POWERSTATE = true;

    public Material material_off;
    public Material material_on;

    Transform Objects;

    // Start is called before the first frame update
    void Start()
    {
        PowerObject = GetComponent<PowerObject>();
        Objects = transform.Find("3D Objects");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PowerUpdate>().UPDATE){
            GetComponent<PowerUpdate>().UPDATE = false;
            PowerObject.UpdateConnections();
            if(POWERSTATE){ PowerObject.PulseConnections(PowerObject.Connections, null);}
        }

    }

    public void UpdateMaterial(bool POWERSTATE){
        foreach(Transform child in Objects.transform){
            if(POWERSTATE){
                child.GetComponent<MeshRenderer> ().material = material_on;
            }
            else{
                child.GetComponent<MeshRenderer> ().material = material_off;
            }
        }
    }

}
