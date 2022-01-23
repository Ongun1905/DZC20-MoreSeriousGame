using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArrow : MonoBehaviour
{
    [Header("Materials")]
    public Material material_off;
    public Material material_on;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateArrow(bool GateState){

        foreach(Transform child in transform){
            if(GateState){
                child.GetComponent<MeshRenderer> ().material = material_on;
            }
            else{
                child.GetComponent<MeshRenderer> ().material = material_off;
            }
        }

    }
}
